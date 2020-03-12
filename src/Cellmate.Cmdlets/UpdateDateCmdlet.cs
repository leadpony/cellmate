#region copyright
/*
 * Copyright 2020 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion
using System;
using System.Management.Automation;
using Microsoft.Office.Interop.Excel;

namespace Cellmate.Cmdlets
{
    [Cmdlet(VerbsData.Update, "DateCell"),
     OutputType(typeof(Workbook))]
    public class UpdateDateCellCmdlet : DateCellCmdlet
    {
        [Parameter(Mandatory = true)]
        public DateTime Value { get; set; }

        [Parameter()]
        public string Format { get; set; } = "m/d/yyyy";

        protected override void ProcessDate(Workbook book, Worksheet sheet, Range cell, DateTime value)
        {
            cell.NumberFormat = this.Format;
            cell.Value = this.Value;
            var address = cell.Address[false, false];
            WriteVerbose($"{book.Name}:{sheet.Name}:{address} {value} => {this.Value}");
        }
    }
}
