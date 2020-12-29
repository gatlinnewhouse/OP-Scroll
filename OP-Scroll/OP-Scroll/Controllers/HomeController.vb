Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Net.Http
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

        Dim client As HttpClient = Controllers.APIController.AuthorizeAPI()



        Using client
            Dim responseTask = client.GetAsync("users/@me")
            responseTask.Wait()

            Dim result = responseTask.Result

            If result.IsSuccessStatusCode Then
                Dim readTask = result.Content.ReadAsStringAsync()

            End If

        End Using



        Return View()
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
