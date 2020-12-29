Imports System.Net.Http
Imports System.Web.Mvc

Namespace Controllers
    Public Class YoutubeAPIController
        Inherits Controller


        Public Shared Function AuthorizeAPI()
            Dim client As New HttpClient With {
            .BaseAddress = New Uri("https://www.googleapis.com/youtube/v3/search?key=AIzaSyAZd__osOvqyIU-Pv59ZyPYVFU4mjJfS1c")
            }


            Return client

        End Function
    End Class
End Namespace