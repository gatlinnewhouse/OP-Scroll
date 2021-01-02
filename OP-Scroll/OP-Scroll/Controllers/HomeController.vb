Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Linq
Imports System.Net.Http.Headers
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class HomeController
    Inherits System.Web.Mvc.Controller


    <HttpGet>
    Function Index() As ActionResult
        ' GetSpotifyLinks()
        Controllers.MalScrapeController.GetSongs(5114)



        'Dim YouTubeLinks As New List(Of String)
        'Dim OpeningYoutubeLinks As New List(Of String)
        'Dim EndingYoutubeLinks As New List(Of String)
        'Dim i = 0
        'Dim ED_Start As Integer = Nothing

        'YouTubeLinks = GetYoutubeLinks()

        'If Not YouTubeLinks Is Nothing Then

        '    For Each song In YouTubeLinks

        '        If song = "EDS" Then
        '            ED_Start = i
        '        End If
        '        i = i + 1
        '    Next

        '    For j As Integer = 0 To ED_Start - 1
        '        OpeningYoutubeLinks.Add(YouTubeLinks(j))

        '    Next

        '    For k As Integer = ED_Start + 1 To YouTubeLinks.Count - 1
        '        EndingYoutubeLinks.Add(YouTubeLinks(k))
        '    Next
        '    ' now can access lists in front end 
        '    ViewBag.OpeningYoutubeLinks = OpeningYoutubeLinks
        '    ViewBag.EndingYoutubeLinks = EndingYoutubeLinks

        'End If




        'Dim resultYT = Controllers.YoutubeAPIController.GetVideoURL("ano hana opening")
        'Dim client As HttpClient = Controllers.APIController.AuthorizeAPI()
        'ViewData("YouTubeLink") = resultYT

        ' get MAL api


        ' GET Youtube API this will be its own function. called by MAL api results return first video id 
        'then in frontend youtubelink schema is https://www.youtube.com/watch?v=




        Return View()
    End Function
    Function GetSpotifyLinks(Optional ByVal song As String = "Roadhouse Blues")
        Dim client As HttpClient = Controllers.SpotifyAPIController.GetSpotifyClient()
        Dim QueryString As String ="search?type=track&limit=1&q=" & song
        Using client
            Dim responseTask = client.GetAsync(QueryString)
            responseTask.Wait()

            Dim result = responseTask.Result
            Dim JsonDrillDown = Nothing
            If result.IsSuccessStatusCode Then
                Dim readTask = result.Content.ReadAsStringAsync().Result



                Dim lsObj = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(readTask)





                Dim data As String = readTask.ToString()

                Dim dilimit As String() = {"track"}
                Dim pieces As String() = data.Split(dilimit, StringSplitOptions.None)
                Dim SongID = Nothing

                For Each piece In pieces
                    If piece.StartsWith("/") Then
                        SongID = Controllers.YoutubeAPIController.getBetween(piece, "/", """"c)
                    End If
                    Console.WriteLine(piece)
                Next





                'For Each item In AnimeList
                '    Console.WriteLine(item)
                'Next

                'AnimeList.RemoveAt(0)
                'Return Json(AnimeList, JsonRequestBehavior.AllowGet)
            Else
                Return Nothing
            End If


        End Using
    End Function
    Function GetYoutubeLinks(Optional ByVal SelectedAnimeID As Integer = 5114)

        ' Getting lists of OPS and EDS for searched Anime 
        Dim SongList As New List(Of String)
        Dim OpeningSongs As New List(Of String)
        Dim EndingSongs As New List(Of String)
        Dim YouTubeLinks As New List(Of String)
        Dim i = 0
        Dim ED_Start As Integer = Nothing
        SongList = Controllers.MalScrapeController.GetSongs(SelectedAnimeID)

        For Each song In SongList

            If song = "EDS" Then
                ED_Start = i
            End If
            i = i + 1
        Next

        For j As Integer = 0 To ED_Start - 1
            OpeningSongs.Add(SongList(j))

        Next

        For k As Integer = ED_Start + 1 To SongList.Count - 1
            EndingSongs.Add(SongList(k))
        Next
        '''''''''''''''''''''''''''''''''''''''''''''
        Dim a = OpeningSongs.Count
        Dim b = EndingSongs.Count
        If Not OpeningSongs Is Nothing Then
            For Each song In OpeningSongs
                YouTubeLinks.Add(Controllers.YoutubeAPIController.GetVideoURL(song))
                Console.WriteLine(song)
            Next
        End If

        If Not EndingSongs Is Nothing Then
            YouTubeLinks.Add("EDS")
            For Each song In EndingSongs
                Console.WriteLine(song)
                YouTubeLinks.Add(Controllers.YoutubeAPIController.GetVideoURL(song))
            Next
        End If



        If Not YouTubeLinks Is Nothing Then
            Return YouTubeLinks
        Else
            Return Nothing
        End If
    End Function


    Function SearchAnime(ByVal SearchKeyWord As String) As JsonResult

        ' MAL API query here to return list... make contract 

        Dim AnimeList As New List(Of String)
        Dim QueryList = Nothing
        Dim QueryString As String = "anime?q=" & SearchKeyWord.ToString() & "&limit=4"

        If QueryString.Length > 2 Then
            Try
                Dim client As HttpClient = Controllers.APIController.AuthorizeAPI()

                Using client
                    Dim responseTask = client.GetAsync(QueryString)
                    responseTask.Wait()

                    Dim result = responseTask.Result
                    Dim JsonDrillDown = Nothing
                    If result.IsSuccessStatusCode Then
                        Dim readTask = result.Content.ReadAsStringAsync().Result



                        Dim lsObj = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(readTask)

                        For Each obj In lsObj
                            If obj.Key = "data" Then

                                Dim data As String = obj.Value.ToString()
                                Dim dilimit As String() = {"node"}
                                Dim pieces As String() = data.Split(dilimit, StringSplitOptions.None)

                                For Each piece In pieces
                                    Dim AddToList = Controllers.YoutubeAPIController.getBetween(piece, "title", "main_picture")
                                    AnimeList.Add(AddToList)
                                Next


                            End If


                        Next
                        For Each item In AnimeList
                            Console.WriteLine(item)
                        Next

                        AnimeList.RemoveAt(0)
                        Return Json(AnimeList, JsonRequestBehavior.AllowGet)
                    Else
                        Return Nothing
                    End If


                End Using
            Catch ex As Exception

            End Try
            'GET API

        End If



        '' fake List 
        'AnimeList.Add("Ano Hana")
        'AnimeList.Add("Agata sense")
        'AnimeList.Add("Ava")
        'AnimeList.Add("Love Hina")
        'AnimeList.Add("Lalalalala la")

        '' make another key called value for the MAL anime ID
        'QueryList = (From items In AnimeList Where items.ToLower().StartsWith(SearchKeyWord.ToLower()) Select New With {
        '    Key .lable = items.ToString()}).ToList()




        'Return Json(QueryList, JsonRequestBehavior.AllowGet)

    End Function


    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
