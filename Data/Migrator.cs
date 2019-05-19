using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Interview.Data
{
    public class Migrator
    {
        public Migrator(DataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public DataAccess DataAccess { get; }

        public void CreateTable<TEntity>()
        {
            var tType = typeof(TEntity);

            var tableName = tType.Name;

            var tableAttribute = tType.GetCustomAttributes(false)
                .Select(a => a as TableAttribute)
                .FirstOrDefault(a => a != null && a.Name != null);

            if (tableAttribute?.Name != null)
            {
                tableName = tableAttribute.Name;
            }

            CreateTable<TEntity>(tableName);
        }

        public void CreateTable<TEntity>(string tableName)
        {
            var script = GenerateCreateScript<TEntity>(tableName);

            DataAccess.Transaction(ctx =>
            {
                ctx.ExecuteCommand(script);
            });
        }

        private string GenerateCreateScript<TEntity>(string tableName)
        {
            Type tableType = typeof(TEntity);

            StringBuilder migrationScript = new StringBuilder();

            migrationScript.AppendLine($"CREATE TABLE {tableName} (");

            foreach (var property in tableType.GetProperties())
            {
                var attributes = property.GetCustomAttributes(false);

                var columnAttribute = attributes
                    .Select(a => a as ColumnAttribute)
                    .FirstOrDefault(a => a != null);

                if (columnAttribute is null)
                {
                    continue;
                }

                var columnScript = GetColumnAddScript(property.PropertyType, property.Name, columnAttribute);

                migrationScript.Append(columnScript + ",");
            }

            migrationScript.Length--;
            migrationScript.AppendLine(");");

            return migrationScript.ToString();
        }

        private string GetColumnAddScript(Type memberType, string memberName, ColumnAttribute columnAttribute)
        {
            string name = columnAttribute.Name ?? memberName;

            // Only support nvarchar max, and int
            string type = columnAttribute.DbType ?? GetDbType(memberType);
            bool isNull = columnAttribute.CanBeNull && !memberType.IsValueType;
            bool isPrimary = columnAttribute.IsPrimaryKey;

            var script = $"{name} {type} {(isPrimary ? "PRIMARY KEY" : string.Empty)} {(isNull ? string.Empty : "NOT NULL")}";
            return script;
        }

        private string GetDbType(Type memberType)
        {
            if (memberType == typeof(int))
            {
                return "[int]";
            }
            else if (memberType == typeof(string))
            {
                return "[nvarchar](max)";
            }

            throw new NotSupportedException(memberType.FullName + " could not be mapped to a supported DbType");
        }
    }
}