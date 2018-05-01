﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.Language.Intellisense.AsyncCompletion
{
    /// <summary>
    /// Provides a hint from <see cref="IAsyncCompletionItemManager"> about how the selected <see cref="CompletionItem"/> should be selected.
    /// </summary>
    public enum CompletionItemSelection
    {
        /// <summary>
        /// Don't change the current selection mode.
        /// </summary>
        NoChange,

        /// <summary>
        /// Set selection mode to soft selection: item is committed only using Tab or mouse.
        /// </summary>
        SoftSelected,

        /// <summary>
        /// Set selection mode to regular selection: item is committed using Tab, mouse, enter and commit characters.
        /// </summary>
        Selected
    }
}