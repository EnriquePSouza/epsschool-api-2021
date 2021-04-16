using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EpsSchool.Domain.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage,
                                        itemsPerPage, totalItems, totalPages);

            var camelCaseFormatter = new JsonSerializerSettings();

            camelCaseFormatter.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination",
                                    JsonConvert.SerializeObject(
                                        paginationHeader, camelCaseFormatter));

            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> self)
        {
            var properties = typeof(T).GetProperties();

            var dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (var info in properties)
                dataTable.Columns.Add(info.Name, Nullable.GetUnderlyingType(info.PropertyType)
                   ?? info.PropertyType);

            foreach (var entity in self)
                dataTable.Rows.Add(properties.Select(p => p.GetValue(entity)).ToArray());

            return dataTable;
        }
    }
}