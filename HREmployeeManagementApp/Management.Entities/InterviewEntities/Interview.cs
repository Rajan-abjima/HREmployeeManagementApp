using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Management.Entities.InterviewEntities;
public class Interview
{
    [Required]
    public string? CandidateName { get; set; }

    [Required]
    public string? PositionApplied { get; set; }

    [Required]
    public DateTime InterviewDate { get; set; }

    [Required]
    public DateTime InterviewTime { get; set; }

    public List<TableColumnData> ColumnData { get; set; }
    public List<TableRowData> RowData { get; set; }


    public class TableRowData
    {
        public List<string> RowName { get; set; }
        public string? Description { get; set; }
        public int RowSequence { get; set; }
    }

    public class TableColumnData
    {
        public string? ColumnName { get; set; }
        public int ColSequence { get; set; }
    }


    public Interview()
    {
        CandidateName = "Purav";
        PositionApplied = "Software Developer";
        InterviewDate = DateTime.Now;
        InterviewTime = DateTime.Now;
        RowData = new()
        {
            new TableRowData
            {
                RowName = new(){"Reviewer", "OK1", "", "OK3" },
                Description = "",
                RowSequence = 1
            },
            
            new TableRowData
            {
                RowName = new(){ "Communication","Good", "Average" },
                Description = "(Way of talking, and English Communication)",
                RowSequence = 2
            },

            new TableRowData
            {
                RowName = new() { "Presentation" },
                Description = "",
                RowSequence = 3
            },

            new TableRowData
            {
                RowName = new() { "Problem Solving Skills" },
                Description = "",
                RowSequence = 4
            }
        };

        ColumnData = new()
        {
            new TableColumnData
            {
                ColumnName = "Interview Round",
                ColSequence = 1
            },

            new TableColumnData
            {
                ColumnName = "Interview Round",
                ColSequence = 2
            },
            
            new TableColumnData
            {
                ColumnName = "Interview Round",
                ColSequence = 3
            }
        };
    }
}
