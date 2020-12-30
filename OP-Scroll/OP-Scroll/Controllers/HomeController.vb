Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Linq
Imports System.Net.Http.Headers

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    'Public Shared Async Function GetAuthToken() As Task(Of String)






    '    'Using client = New HttpClient()
    '    '    client.BaseAddress = New Uri(URL)

    '    '    Dim response As HttpResponseMessage = New HttpResponseMessage()
    '    '    response = Await client.GetAsync("/users/@me")



    '    '    If response.IsSuccessStatusCode Then

    '    '        Dim readTask = Await response.Content.ReadAsStringAsync()
    '    '        Return readTask

    '    '    Else
    '    '        Return Nothing
    '    '    End If


    '    'End Using


    'End Function
    <HttpGet>
    Function Index() As ActionResult

        Dim resultYT = Controllers.YoutubeAPIController.GetVideoURL("ano hana opening")
        Dim client As HttpClient = Controllers.APIController.AuthorizeAPI()
        ViewData("YouTubeLink") = resultYT

        ' get MAL api
        Using client
            Dim responseTask = client.GetAsync("users/@me")
            responseTask.Wait()

            Dim result = responseTask.Result

            If result.IsSuccessStatusCode Then
                Dim readTask = result.Content.ReadAsStringAsync()

            End If

        End Using


        ' GET Youtube API this will be its own function. called by MAL api results return first video id 
        'then in frontend youtubelink schema is https://www.youtube.com/watch?v=




        Return View()
    End Function


    Function SearchAnime(ByVal SearchKeyWord As String) As JsonResult

        ' MAL API query here to return list... make contract 

        Dim AnimeList As New List(Of String)
        Dim QueryList = Nothing

        ' fake List 
        AnimeList.Add("Ano Hana")
        AnimeList.Add("Agata sense")
        AnimeList.Add("Ava")
        AnimeList.Add("Love Hina")
        AnimeList.Add("Lalalalala la")

        ' make another key called value for the MAL anime ID
        QueryList = (From items In AnimeList Where items.ToLower().StartsWith(SearchKeyWord.ToLower()) Select New With {
            Key .lable = items.ToString()}).ToList()




        Return Json(QueryList, JsonRequestBehavior.AllowGet)

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
