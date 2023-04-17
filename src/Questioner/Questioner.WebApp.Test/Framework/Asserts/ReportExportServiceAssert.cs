using ClosedXML.Excel;

namespace Questioner.WebApp.Test.Framework.Asserts
{
    internal static class ReportExportServiceAssert
    {
        public static void AreEqual(XLWorkbook expected, XLWorkbook actual)
        {
            Assert.That(actual.Worksheets, Has.Count.EqualTo(expected.Worksheets.Count),
                message: $"The expected Worksheets number should be {expected.Worksheets.Count} and not {actual.Worksheets.Count}.");

            for (int worksheetIndex = 0; worksheetIndex < expected.Worksheets.Count; worksheetIndex++)
            {
                var actualWorksheet = actual.Worksheets.ToArray()[worksheetIndex];
                var expectedWorksheet = expected.Worksheets.ToArray()[worksheetIndex];

                Assert.Multiple(() =>
                {
                    Assert.That(actualWorksheet.Name, Is.EqualTo(expectedWorksheet.Name),
                        message: $"Worksheet number {worksheetIndex}, the name should be {expectedWorksheet.Name} and not {actualWorksheet.Name}.");

                    Assert.That(actualWorksheet.Rows().Count(), Is.EqualTo(expectedWorksheet.Rows().Count()),
                        message: $"{expectedWorksheet.Name} worksheet rows should be {expectedWorksheet.Rows().Count()} and not {actualWorksheet.Rows().Count()}.");

                    Assert.That(actualWorksheet.Columns().Count(), Is.EqualTo(expectedWorksheet.Columns().Count()),
                        message: $"{expectedWorksheet.Name} worksheet columns should be {expectedWorksheet.Columns().Count()} and not {actualWorksheet.Columns().Count()}.");
                });

                for (int columnIndex = 0; columnIndex < expectedWorksheet.Columns().Count(); columnIndex++)
                {
                    var actualColumn = actualWorksheet.Columns().ToArray()[columnIndex];
                    var expectedColumn = expectedWorksheet.Columns().ToArray()[columnIndex];

                    for (int rowIndex = 1; rowIndex <= expectedWorksheet.Rows().Count(); rowIndex++)
                    {
                        var actualCell = actualColumn.Cell(rowIndex);
                        var expectedCell = expectedColumn.Cell(rowIndex);

                        Assert.That(actualCell.Value, Is.EqualTo(expectedCell.Value),
                            message: $"The in the {expectedCell.Address.ColumnNumber}{expectedCell.Address.ColumnNumber} column, {expectedCell.Address.RowNumber} row, the expected value should be {expectedCell.Value} and not {actualCell.Value}.");
                    }
                }
            }
        }
    }
}
