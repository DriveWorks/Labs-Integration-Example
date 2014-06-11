Imports System.Collections.Concurrent
Imports System.Runtime.CompilerServices
Imports DriveWorks

Public Module ProjectExtensions
    ReadOnly mSharedObjectsTable As New ConditionalWeakTable(Of Project, SharedObjectContainer)()

    <Extension>
    Public Function GetSharedObject(Of T As {Class, New})(ByVal project As Project) As T
        If project Is Nothing Then
            Return Nothing
        End If

        Return mSharedObjectsTable.GetOrCreateValue(project).GetOrCreate(Of T)()
    End Function

    Private Class SharedObjectContainer
        Private ReadOnly mSharedObjects As New ConcurrentDictionary(Of Type, Object)()

        Public Function GetOrCreate(Of T As {Class, New})() As T

            Return DirectCast(mSharedObjects.GetOrAdd(GetType(T), Factory(Of T).MakeDelegate), T)
        End Function

        Private NotInheritable Class Factory(Of T As {Class, New})
            Private Sub New()
            End Sub

            Public Shared Function Make(type As Type) As Object
                Return New T()
            End Function

            Public Shared ReadOnly MakeDelegate As New Func(Of Type, Object)(AddressOf Make)
        End Class
    End Class
End Module




