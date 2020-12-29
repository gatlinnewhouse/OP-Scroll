Imports System.Net.Http
Imports System.Web.Mvc
Imports System.Text

Namespace Controllers
    Public Class YoutubeAPIController
        Inherits Controller


        Public Shared Function AuthorizeAPI()
            Dim client As New HttpClient With {
            .BaseAddress = New Uri("https://www.googleapis.com/youtube/v3/search?key=AIzaSyAZd__osOvqyIU-Pv59ZyPYVFU4mjJfS1c&part=snippet&q=Redo by Konomi Suzuki")
            }


            Return client

        End Function

        ' Untested, should return the json as a string from the youtube query
        ' then finds videoId from json result
        ' then concatenates videoId to end of youtube watch URL and returns video URL
        Public Shared Function GetVideoURL(String query)
            Dim request As String = String.Format("https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=1&q={0}&key=AIzaSyAZd__osOvqyIU-Pv59ZyPYVFU4mjJfS1c", query.Text)
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString(request)
            Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)
            Dim videoId = jsonResulttodict.item ("videoId")
            Dim videoURL As String = String.Format("https://www.youtube.com/watch?v={0}", videoId.Text)
            return videoURL
        End Function

    End Class
End Namespace