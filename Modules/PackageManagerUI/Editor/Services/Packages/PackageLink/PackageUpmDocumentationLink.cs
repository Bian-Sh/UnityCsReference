// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEditor.PackageManager.UI.Internal
{
    internal class PackageUpmDocumentationLink : PackageLink
    {
        public PackageUpmDocumentationLink(IPackageVersion version) : base(version)
        {
        }

        public override bool isVisible => version != null && version.HasTag(PackageTag.UpmFormat) && !version.HasTag(PackageTag.Feature);
        public override bool isEnabled => !isEmpty || version.HasTag(PackageTag.BuiltIn);
        public override ContextMenuAction[] contextMenuActions => new ContextMenuAction[] { ContextMenuAction.OpenInBrowser, ContextMenuAction.OpenLocally };

        public override string tooltip
        {
            get
            {
                if (isEnabled)
                    return L10n.Tr("Right click to see viewing options: in browser or local.");
                else if (version.package.product != null && !version.isInstalled)
                    return L10n.Tr("Install to view documentation");
                else
                    return L10n.Tr("Documentation unavailable");
            }
        }
    }
}
