
using Taxi_Backend.Helper;

namespace Taxi_Backend.Models
{
    public class Page
    {
        public Page(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public Page(int pageNumber, int pageSize, string orderColumn, bool isAscending)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderColumn = orderColumn ?? string.Empty;
            IsAscending = isAscending;
        }
        // starts from 1
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderColumn { get; set; }
        public bool IsAscending { get; set; }
        public List<Filter> Filters { get; set; } = new();

        public int Skip { get => (PageNumber - 1) * PageSize; }
        public int Take { get => PageSize; }
        public async Task<(int, List<T>)> Get<T>(IQueryable<T> data)
        {
            var filteredData = data;
            if (Filters.Count > 0)
            {
                var deleg = ExpressionBuilder.GetExpression<T>(Filters).Compile();
                filteredData = data.Where(deleg).AsQueryable();
            }
            if (OrderColumn.Length > 0) filteredData = filteredData.OrderBy(OrderColumn, IsAscending);
            var res = await Task.FromResult(filteredData.Skip(Skip).Take(Take).ToList());
            var count = await Task.FromResult(filteredData.Count());
            return (count, res);
        }

    }


    public class Filter
    {
        public Filter(string propertyName, Op operation, object value)
        {
            PropertyName = new List<string> { propertyName };
            Operation = operation;
            Value = value;
        }
        public Filter(List<string> propertyName, Op operation, object value)
        {
            PropertyName = propertyName;
            Operation = operation;
            Value = value;
        }
        public List<string> PropertyName { get; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }

    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
}


