Imports System.Web.Mvc
Imports System.Net.Http

Namespace Controllers
    Public Class APIController
        Inherits Controller

        Public Shared Function AuthorizeAPI()
            Dim client As New HttpClient With {
            .BaseAddress = New Uri("https://api.myanimelist.net/v2/")
            }

            Dim Key As String = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjRiNDkzZTJmODc0OWJhNmE0ZjAwODQxMTJkYTM4ZDc4ZDFhZGVlZGViN2UxN2JlZWIyNjM1MmVlMDc5N2U5ODU4MDM5MDZmMmE5OTZkMTFkIn0.eyJhdWQiOiJkNDg2MWJjMGZjNGViNWFiZTJiYWNiOWU5NjZkODE1NCIsImp0aSI6IjRiNDkzZTJmODc0OWJhNmE0ZjAwODQxMTJkYTM4ZDc4ZDFhZGVlZGViN2UxN2JlZWIyNjM1MmVlMDc5N2U5ODU4MDM5MDZmMmE5OTZkMTFkIiwiaWF0IjoxNjA5MjAxNDg5LCJuYmYiOjE2MDkyMDE0ODksImV4cCI6MTYxMTg3OTg4OSwic3ViIjoiNzE4OTk4NyIsInNjb3BlcyI6W119.lDBMcSmZ5eTiDhwnN-iHxl7DcUyAQSYshhMDanWD-byH5r2fh6AKSjqSXjpE5a-_dMVy5Zk2Ub5fVwA9seO1ODgbpLV_HEuhoY87mvOzZOh4c8zoK2odFsdyHoBSU3AEMNHN-zvdzkd5w7Sk7Pce4jzFI1I65WG_xG15PQbQHgFJ78-rHv3aGB1SuSH3Gh3IsG0C3YHLOhRe2aHUx51W0ztAZCTkom3NXzr5S0EvhpJbVsH6N1B6tWt2qmN0M4RJfwKrZhooM78ygAe0_TDlgWuiOyqZDMjOyoQg_avM-gEDKkJoiDyUqiSEbLVi4dmLJuhRlMkVAwHie6TDIDW_jg"

            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", Key)

            Return client

        End Function

    End Class
End Namespace