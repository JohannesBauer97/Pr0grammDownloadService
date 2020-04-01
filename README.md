# Pr0gramm Download Service [![](https://images.microbadger.com/badges/version/serverlein/pr0download.svg)](https://microbadger.com/images/serverlein/pr0download "Get your own version badge on microbadger.com") ![.NET Core](https://github.com/JohannesBauer97/Pr0grammDownloadService/workflows/.NET%20Core/badge.svg?branch=master)
A lightweight REST-API which returns direct links to pr0gramm media files.

![alt text](https://raw.githubusercontent.com/JohannesBauer97/Pr0grammDownloadService/develop/.github/screens/v1.png "Swagger API Documentation")

## Features
* No pr0gramm account or configuration needed
* Works for (public) sfw content
* Swagger Documentation
* Rate Limit (to avoid DOS attacks through this service): max. 3 requests in 10 seconds

## Getting Started

### Prerequisite
* Docker Engine / Docker Desktop

Run: `docker run serverlein/pr0download:latest -p 1040:1040`

Swagger documentation available http://localhost:1040

### Docker Compose
```
version: '3.7'
services:
    service:
        image: serverlein/pr0download:latest
        restart: always
        ports:
            - "1040:1040"
```
## Use this service to download videos with Apple iOS Shortcuts
<img src="https://raw.githubusercontent.com/JohannesBauer97/Pr0grammDownloadService/develop/.github/screens/shortcutv1.png" width="400">
