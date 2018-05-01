﻿using System.Diagnostics;
using Microsoft.VisualStudio.Text.Utilities;
using Microsoft.VisualStudio.Utilities.Features;

namespace Microsoft.VisualStudio.Language.Intellisense.AsyncCompletion.Implementation
{
    /// <summary>
    /// Provides information whether modern completion should be enabled, given the buffer's content type.
    /// </summary>
    internal static class ModernCompletionFeature
    {
        private const string TreatmentFlightName = "CompletionAPI";
        private static bool _treatmentFlightEnabled;
        private static bool _treatmentFlightDataInitialized;

        /// <summary>
        /// Returns whether or not modern completion should be enabled.
        /// </summary>
        /// <returns>true if experiment is enabled.</returns>
        public static bool GetFeatureState(IExperimentationServiceInternal experimentationService, IFeatureService featureService)
        {
            if (!featureService.IsEnabled(PredefinedEditorFeatureNames.Completion))
                return false;

            if (_treatmentFlightDataInitialized)
                return _treatmentFlightEnabled;

#if DEBUG
            _treatmentFlightEnabled = true;
#else
            _treatmentFlightEnabled = experimentationService.IsCachedFlightEnabled(TreatmentFlightName);
#endif
            _treatmentFlightDataInitialized = true;
            return _treatmentFlightEnabled;
        }
    }
}