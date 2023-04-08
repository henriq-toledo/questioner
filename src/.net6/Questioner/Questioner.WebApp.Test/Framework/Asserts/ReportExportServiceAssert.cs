using ClosedXML.Excel;
using NUnit.Framework;
using System.Linq;

namespace Questioner.WebApp.Test.Framework.Asserts
{
    internal static class ReportExportServiceAssert
    {
        public static void AreEqual(XLWorkbook expected, XLWorkbook actual)
        {
            Assert.AreEqual(expected.Worksheets.Count, actual.Worksheets.Count,
                message: $"The expected Worksheets number should be {expected.Worksheets.Count} and not {actual.Worksheets.Count}.");

            for (int worksheetIndex = 0; worksheetIndex < expected.Worksheets.Count; worksheetIndex++)
            {
                var actualWorksheet = actual.Worksheets.ToArray()[worksheetIndex];
                var expectedWorksheet = expected.Worksheets.ToArray()[worksheetIndex];

                Assert.AreEqual(expectedWorksheet.Name, actualWorksheet.Name,
                    message: $"Worksheet number {worksheetIndex}, the name should be {expectedWorksheet.Name} and not {actualWorksheet.Name}.");

                Assert.AreEqual(expectedWorksheet.Rows().Count(), actualWorksheet.Rows().Count(),
                    message: $"{expectedWorksheet.Name} worksheet rows should be {expectedWorksheet.Rows().Count()} and not {actualWorksheet.Rows().Count()}.");

                Assert.AreEqual(expectedWorksheet.Columns().Count(), actualWorksheet.Columns().Count(),
                    message: $"{expectedWorksheet.Name} worksheet columns should be {expectedWorksheet.Columns().Count()} and not {actualWorksheet.Columns().Count()}.");

                for (int columnIndex = 0; columnIndex < expectedWorksheet.Columns().Count(); columnIndex++)
                {
                    var actualColumn = actualWorksheet.Columns().ToArray()[columnIndex];
                    var expectedColumn = expectedWorksheet.Columns().ToArray()[columnIndex];

                    for (int rowIndex = 1; rowIndex <= expectedWorksheet.Rows().Count(); rowIndex++)
                    {
                        var actualCell = actualColumn.Cell(rowIndex);
                        var expectedCell = expectedColumn.Cell(rowIndex);

                        Assert.AreEqual(expectedCell.Value, actualCell.Value,
                            message: $"The in the {expectedCell.Address.ColumnNumber}{expectedCell.Address.ColumnNumber} column, {expectedCell.Address.RowNumber} row, the expected value should be {expectedCell.Value} and not {actualCell.Value}.");
                    }
                }
            }
        }
    }
}
