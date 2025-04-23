using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace FolderCsFileOpener
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(FolderCsFileOpenerPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class FolderCsFileOpenerPackage : AsyncPackage
    {
        public const string PackageGuidString = "c9c3d4e5-384e-447a-9791-eb2d8649b7fe";

        protected override async Task InitializeAsync(
            CancellationToken cancellationToken,
            IProgress<ServiceProgressData> progress)
        {
            //System.Diagnostics.Debug.WriteLine($"[InitializeAsync] CurrentUICulture: {System.Threading.Thread.CurrentThread.CurrentUICulture}");

            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await FolderOpenCommand.InitializeAsync(this);
        }
    }
}
