﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.IO;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFileContent")]
    public class GetBatchTaskFileContentCommand : BatchObjectModelCmdletBase
    {
        [Parameter(Position = 0, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the workitem containing the target task.")]
        [ValidateNotNullOrEmpty]
        public string WorkItemName { get; set; }

        [Parameter(Position = 1, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job containing the target task.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(Position = 2, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the task.")]
        [ValidateNotNullOrEmpty]
        public string TaskName { get; set; }

        [Parameter(Position = 3, ParameterSetName = Constants.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the task file to download.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = Constants.InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The PSTaskFile object representing the task file to download.")]
        [ValidateNotNullOrEmpty]
        public PSTaskFile InputObject { get; set; }

        [Parameter(HelpMessage = "The path to the directory where the task file will be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        /// <summary>
        /// Used for testing. If not null, the file contents will be copied to this Stream instead of hitting the file system.
        /// </summary>
        internal Stream Stream;

        public override void ExecuteCmdlet()
        {
            DownloadTaskFileOptions options = new DownloadTaskFileOptions(this.BatchContext, this.WorkItemName, this.JobName, 
                this.TaskName, this.Name, this.InputObject, this.AdditionalBehaviors)
            {
                DestinationPath = this.DestinationPath,
                Stream = this.Stream
            };

            BatchClient.DownloadTaskFile(options);
        }
    }
}
