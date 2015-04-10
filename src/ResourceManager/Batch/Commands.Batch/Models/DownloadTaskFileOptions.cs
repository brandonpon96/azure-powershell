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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class DownloadTaskFileOptions : TaskFileOperationParameters
    {
        public DownloadTaskFileOptions(BatchAccountContext context, string workItemName, string jobName, string taskName, string taskFileName,
            PSTaskFile taskFile, IEnumerable<BatchClientBehavior> additionalBehaviors = null) 
            : base(context, workItemName, jobName, taskName, taskFileName, taskFile, additionalBehaviors)
        { }

        /// <summary>
        /// The path to the directory where the Task file will be downloaded
        /// </summary>
        public string DestinationPath { get; set; }

        /// <summary>
        /// Used for testing. If not null, the file contents will be copied to this Stream instead of hitting the file system.
        /// </summary>
        internal Stream Stream { get; set; }
    }
}
