using Management.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

    public List<TableRowData>? RowData { get; set; }
    public List<TableColumnData>? ColumnData { get; set; }




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
                RowName = "Communication",
                Description = "(Way of talking, and English Communication)",
                RowSequence = 1
            },

            new TableRowData
            {
                RowName = "Presentation",
                Description = "",
                RowSequence = 2
            },

            new TableRowData
            {
                RowName = "Problem Solving Skills",
                Description = "",
                RowSequence = 3
            }
        };

        ColumnData = new()
        {
            new TableColumnData
            {
                ColummName = "Interview Round 1",
                ColSequence = 1
            },

            new TableColumnData
            {
                ColummName = "Interview Round 2",
                ColSequence = 2
            }
        };
    }



}
