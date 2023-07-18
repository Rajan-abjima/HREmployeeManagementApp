using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Models;
public class InterviewModel
{
    [Required]
    public string? CandidateName { get; set; }

    [Required]
    public string? PositionApplied { get; set; }

    [Required]
    public DateTime InterviewDate { get; set; }
    
    [Required]
    public DateTime InterviewTime { get; set; }

    public List<TableRowData>? RowData { get; set; }
    public List<TableColumnData>? ColumnData { get; set; }







    //class Table<T>
    //{
    //    private T[][]? _Data;

    //    public T[][]? Data
    //    {
    //        get { return _Data; }
    //        set { _Data = value; }
    //    }
    //}

    //public IDictionary<int, TableRowData> rowData = new Dictionary<int, TableRowData>();

    //public object[][] TableData = new object[][] {new TableRowData[] { }, new TableColumnData[] { }};
}

public class TableRowData
{
    public string? RowName { get; set; }
    public string? Description { get; set; }
    public int RowSequence { get; set; }
}

public class TableColumnData
{
    public string? ColummName { get; set; }
    public int ColSequence { get; set; }
}


