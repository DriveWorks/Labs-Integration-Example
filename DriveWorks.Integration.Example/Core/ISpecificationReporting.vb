Imports DriveWorks.Applications
Imports DriveWorks.Reporting

Public Class ISpecificationReporting

    Implements IApplicationEventService

    Public Event EventLogged(sender As Object, e As ApplicationEventEventArgs) Implements IApplicationEventService.EventLogged
    Public Event EventsCleared(sender As Object, e As EventArgs) Implements IApplicationEventService.EventsCleared

    Private mSpecReport As IReportWriter

    Public Sub New(specReport As IReportWriter)

        mSpecReport = specReport

    End Sub

    Public Sub AddEvent(type As ApplicationEventType, sourceInvariantName As String, sourceDisplayName As String, description As String, targetInvariantName As String, targetDisplayName As String, url As String) Implements IApplicationEventService.AddEvent

        Dim entryType As ReportEntryType

        ' the 2 reporting types have different enums which need normalising
        Select Case type
            Case ApplicationEventType.Error
                entryType = ReportEntryType.Error
            Case ApplicationEventType.Information
                entryType = ReportEntryType.Information
            Case ApplicationEventType.Warning
                entryType = ReportEntryType.Warning
        End Select

        ' always write as minimal
        mSpecReport.WriteEntry(ReportingLevel.Minimal, entryType, sourceDisplayName, targetDisplayName, description, url)

    End Sub

    Public Sub ClearEvents() Implements IApplicationEventService.ClearEvents

        ' we aren't expecting this to be called for our report
        Throw New Exception

    End Sub

    Public Function GetEvents() As IApplicationEvent() Implements IApplicationEventService.GetEvents

        ' we aren't expecting this to be called for our report
        Throw New Exception

    End Function
End Class
