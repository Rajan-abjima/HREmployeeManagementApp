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
}

public class TableRowData
{
    public string? RowName { get; set; }
    public string? Description { get; set; }
    public int RowSequence { get; set; }
}

public class TableColumnData
{
    public string? ColumnName { get; set; }
    public int ColSequence { get; set; }
}


