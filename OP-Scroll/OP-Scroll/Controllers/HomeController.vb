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

        Dim resultYT = Controllers.YoutubeAPIController.GetVideoURL("ano hana opening")
        Dim client As HttpClient = Controllers.APIController.AuthorizeAPI()
        ViewData("YouTubeLink") = resultYT

        ' get MAL api


        ' GET Youtube API this will be its own function. called by MAL api results return first video id 
        'then in frontend youtubelink schema is https://www.youtube.com/watch?v=




        Return View()
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
                        Dim count = AnimeList.Count

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
