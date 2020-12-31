Imports System.Net.Http
Imports System.Web.Mvc
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Controllers
    Public Class YoutubeAPIController
        Inherits Controller


        'call GetVideoURL() with parameter anime name and it returns first most rel youtube video 


        Public Shared Function GetVideoURL(ByVal query As String)
            Dim request As String = String.Format("https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=1&q={0}&key=AIzaSyAZd__osOvqyIU-Pv59ZyPYVFU4mjJfS1c", query)
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString(request)

            Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)
            Dim jsonDrillDown = Nothing
            For Each item In jsonResulttodict
                If item.Key = "items" Then
                    jsonDrillDown = item.Value

                End If

            Next

            Dim videoID As String = getBetween(jsonDrillDown.ToString(), "videoId", "},")


            Dim videoURL As String = String.Format("https://www.youtube.com/embed/{0}", videoID)
            Console.WriteLine(videoURL)
            Return videoURL
        End Function


        Public Shared Function getBetween(ByVal strSource As String, ByVal strStart As String, ByVal strEnd As String) As String
            If strSource.Contains(strStart) AndAlso strSource.Contains(strEnd) Then
                Dim Start, [End] As Integer
                Start = strSource.IndexOf(strStart, 0) + strStart.Length
                [End] = strSource.IndexOf(strEnd, Start)
                Return strSource.Substring(Start, [End] - Start).Replace("""", "").Trim(New Char() {" "c, "&"c, ":"c}).Replace("vbCrLf", "")
            Else
                Return Nothing

            End If


        End Function

    End Class





End Namespace