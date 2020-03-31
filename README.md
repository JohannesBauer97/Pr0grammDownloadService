# Pr0gramm Download Service [![](https://images.microbadger.com/badges/version/serverlein/pr0download.svg)](https://microbadger.com/images/serverlein/pr0download "Get your own version badge on microbadger.com")
A lightweight REST-API which returns direct links to pr0gramm media files.

## Getting Started

### Prerequisite
* Docker Engine / Docker Desktop

Run: `docker run serverlein/pr0download:latest -p 1040:1040`

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
