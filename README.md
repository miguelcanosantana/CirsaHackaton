# CirsaHackaton

## 🌐 Website
https://miguelcanosantana.github.io/CirsaHackaton/

###### Data is not saved when reloading or closing the page as this is a local app.
There is a test user with some example data precharged:
- User: testuser@example.com
- Password: 123456789

## 📒 User Guide
![Landing page](./wwwroot/Images/001.png)
This is the landing page. With a brief presentation of the web app. To navigate between pages use the top navbar.

![Register page](./wwwroot/Images/002.png)
You can register a profile clicking in `Crear Cuenta de Afiliado`. (Keep in mind there is no data saving, reloading the browser deletes user info).

![Login page](./wwwroot/Images/003.png)
You can login too clicking in `Iniciar Sesión`, it's recommended to use the fake profile in the top section of this readme.

![Dashboard](./wwwroot/Images/004.png)
When registering or loging succesfully, you will be redirected to the dashboard page, here you can manage the affiliate referral page appearance.

- `Textos` > `Título`: You can change the title of the invitation.
- `Textos` > `Description`: You can give a description about the referral advantages.
- `Imágenes` > `Imagen Avatar` (Not implemented): You can change the avatar image of the user in the invite.
- `Imágenes` > `Fondo Tilleable`: Use a tilleable pattern background to display in the message.
- `Compartir` > `Link de afiliado`: Share this link to share the referral invitation (Keep in mind it only works for the test profile as there is no data saving feature)
- `Guardar` > `Guardar estilo`: Saves the style.
- `Guardar` > `Ver invitación`: Previews the invitation (Use this button if you made changes and pressed `Guardar estilo` instead just copying the code.

![Referral](./wwwroot/Images/005.png)
Default customer invitation.

## 💻 Technologies used
- [Blazor (WebAssembly)](https://dotnet.microsoft.com/es-es/apps/aspnet/web-apps/blazor)
- [Bootstrap V5.3](https://getbootstrap.com/docs/5.3)
- [Net Core](https://dotnet.microsoft.com/es-es/download)

## 🚀 How to Deploy 
This turorial has been used to deploy the site to github pages. [Tutorial](https://ilovedotnet.org/blogs/blazor-wasm-publishing-to-github-pages/)

Using a custom Github Action, in this case would be the following:
```
name: github pages

# Run workflow on every push to the master branch
on:
  push:
    branches:
      - main
  pull_request:
    branches:
      - main

jobs:
  deploy-to-github-pages:
  # use ubuntu-latest image to run steps on
    runs-on: ubuntu-latest
    steps:
    # uses GitHub's checkout action to checkout code form the main branch
    - uses: actions/checkout@v2

    # sets up .NET Core SDK 6.0.x
    - name: Setup .NET Core SDK
      uses: actions/setup-dotnet@v3.2.0

    # Install dotnet wasm buildtools workload
    - name: Install .NET WASM Build Tools
      run: dotnet workload install wasm-tools

    # Publishes Blazor project to the release-folder
    - name: Publish .NET Core Project
      run: dotnet publish ./CirsaHack.csproj -c:Release -p:GHPages=true -o dist/Web --nologo

    - name: Commit wwwroot to GitHub Pages
      uses: JamesIves/github-pages-deploy-action@3.7.1
      with:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        BRANCH: gh-pages
        FOLDER: dist/Web/wwwroot
```

🚦 Inside the Repo Settings > Actions > General in the Workflow permissions category, allow Read and Write permissions.

🗒️ This repo has 2 branches, the main one, and the gh-pages, created automatically by the action. 
The page content is only generated with those files in the second branch.

## 🦄 Taken decisions
### 📆 First day
It was my first project ever using *Blazor*.
So my first decision and when I got stuck for the most time was uploading the project to github pages.
When I finally did, I started looking for documentation of the project as a total newbie to this framework 💁🏻‍♂️


Here are some of the links I've fund helpful under my entire development:
- https://ilovedotnet.org/blogs/blazor-wasm-publishing-to-github-pages/
- https://www.youtube.com/watch?v=aKYLx-YOPAg
- https://www.youtube.com/watch?v=4G_BzLxa9Nw
- https://www.youtube.com/watch?v=VDkiB5F7FH0
- https://learn.microsoft.com/en-us/answers/questions/1189167/blazor-visual-studio-sample-template-missing-boots
- https://github.com/martinmogusu/blazor-top-navbar
- https://stackoverflow.com/questions/58221915/difference-between-bind-and-bind-value
- https://wellsb.com/csharp/aspnet/blazor-singleton-pass-data-between-pages
- https://subscription.packtpub.com/book/web-development/9781800567511/2/ch02lvl1sec12/routing-in-blazor-webassembly
- https://stackoverflow.com/questions/59518988/disable-layout-for-page-under-blazor

Having some of previous experiences in *Ionic* and *Angular* I've found some behaviours are really similar, so I decided to make a Service architecture.

A Singleton service for getting user's info is inyected in each page and component that needs it.

### 📆 Second/Third day
Having lost a lot of time the first day figuring out how everything worked, the second and third day were faster.
