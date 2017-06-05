Imports DriveWorks.Specification
Imports DriveWorks.GroupMaintenance

<Task("Package Group",
      "embedded://DriveWorks.Integration.Example.Puzzle-16x16.png")>
Public Class PackageGroupTask
    Inherits Task

    Private mSaveLocation As FlowProperty(Of String) =
        Me.Properties.RegisterStringProperty(
            "Save Location",
            New FlowPropertyInfo(
                "Where to save the package to.",
                "Test"))

    Protected Overrides Sub Execute(ctx As SpecificationContext)

        Dim fileOptions As New FilePickingOptions(ctx.Group.GroupContentFolder)
        fileOptions.ExcludeFolders.Add(ctx.Group.DefaultSpecificationFolder)

        Dim options As New CopyGroupOptions() With {
            .CopyNewSecurityObjects = True,
            .CopySpecifications = False,
            .CopyReleaseData = False,
            .CopyTasks = False,
            .FileOptions = fileOptions
        }

        options.Projects.AddRange(ctx.Group.Projects.GetProjects())
        options.CapturedComponents.AddRange(ctx.Group.CapturedComponents.GetComponents())
        options.GroupTables.AddRange(ctx.Group.DataTables)

        Using packager = PackageGroupProcess.CreatePackageGroupProcess(ctx.Group,
                                                                       mSaveLocation.Value,
                                                                       ctx.Group.Name,
                                                                       options)

            packager.Start()
        End Using
    End Sub
End Class
