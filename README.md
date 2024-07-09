# MetricPusher

## Overview

`MetricPusher` is a .NET console application that sends metrics data to the localhost endpoint of a OneAget.
The application reads metrics data from a multiline string and sends it in bulk as a single POST request.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)

## Getting Started

### Clone the Repository

First, clone the repository to your local machine:

```bash
git clone <repository-url>
cd MetricPusher
```

### Build the Application

To build the application, use the following command:

```bash
dotnet build
```

### Run the Application 

To run the application, use the following command:

```bash
dotnet run 
```


### Sample run

```
PS MetricPusher\bin\Release\net8.0\win-x64\publish> .\MetricPusher.exe
Response: {
    "error": null,
    "linesOk": 4,
    "linesInvalid": 0
}
```

