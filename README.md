# CirsaHackaton

## 🌐 Website
https://miguelcanosantana.github.io/CirsaHackaton/

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

Inside the Repo Settings > Actions > General in the Workflow permissions category, allow Read and Write permissions.
