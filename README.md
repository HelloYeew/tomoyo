# Tomoyo

"The greatest happiness for me is to let the person I most like have the most happiness." - Tomoyo Daidouji

Tomoyo is an image gallery site + (a bit) social network that's build specifically for share an image from an anime exhibition, event and more.

_TODO: Write full description_

## Develop Tomoyo

Tomoyo is build using ASP.NET Core on .NET 9.0. Frontend based on [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) SSR and [MudBlazor](https://mudblazor.com/).

### Requirement

- [.NET 9 SDK](https://dotnet.microsoft.com)
- ASP.NET (Already included in .NET SDK)

### Setup database from EFCore

```shell
dotnet ef database update
```

### Run the server

```shell
dotnet run
# Or use dotnet watch for hot reload
dotnet watch
```

## License

Tomoyo is licensed under the MIT license. Please see [the licence file](LICENSE) for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.