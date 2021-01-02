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
            Dim index = query.IndexOf("(ep")

            Dim newquery = Nothing

            If index > 0 Then
                newquery = query.Substring(0, index)

            End If

            Dim index2 = newquery.IndexOf("#")

            newquery = newquery.Substring(index2 + 3)


            Dim output As String = query.Substring(query.IndexOf(")"c) + 1)

            Dim request As String = String.Format("https://youtube.googleapis.com/youtube/v3/search?part=snippet&maxResults=1&q={0}&key=AIzaSyABdOQV0yCPBenzbJiKC6tWVmqb7jHliqM", HttpUtility.UrlEncode(newquery))
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
