# DD.NameSorter - .NET 8 Name Sorter Console Application

### CI Badge

![.NET Build Status](https://github.com/Sandisiwe-Vutula/DD.NameSorter/actions/workflows/dotnet.yml/badge.svg)


## Overview

`DD.NameSorter` is a clean, SOLID-compliant .NET 8 console application for **D&D assessment**. It reads a list of names from a file, sorts them alphabetically by **last name**, then by **given names**, and outputs the sorted list both to the console and a file called `sorted-names-list.txt`.

> Built with clean architecture, async file handling, logging, and CI/CD via GitHub Actions.

---

## Project Architecture

```text
DD.NameSorter/
 - DD.NameSorter.Models/           # Domain models 
 - DD.NameSorter.Services/         # Services (FileService, NameSortingService, & interfaces)
 - DD.NameSorter.Console/          # Main entry point
 - DD.NameSorter.Infrastructure/   # Infrastructure (Parser utility & interface)
 - DD.NameSorter.Tests/            # Unit test
```

---

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- Git CLI
- Visual Studio 2022 or VS Code

---

### Run Locally

```bash
# 1. Clone the repository
git clone https://github.com/Sandisiwe-Vutula/DD.NameSorter.git
cd DD.NameSorter

# 2. Build the solution
dotnet build

# 3. Execute the program using input file path
./unsorted-names-list.txt
```

### Expected Output

- Sorted names printed to console
- File `sorted-names-list.txt` created or overwritten in working directory

---

## Running Tests

The solution includes unit tests using `xUnit` and `Moq`.

```bash
dotnet test
```

Test areas:
- Name validations
- File I/O handling
- Sorting logic by last name and given names
- Edge cases (blank lines, missing files, duplicate names, etc...)

---

## Input/Output Sample

### `unsorted-names-list.txt`
```
 Janet Parsons
 Vaughn Lewis
 Adonis Julius Archer
 Shelby Nathan Yoder
 Marin Alvarez
 London Lindsey
 Beau Tristan Bentley
 Leo Gardner
 Hunter Uriah Mathew Clarke
 Mikayla Lopez
 Frankie Conner Ritter
```

### `sorted-names-list.txt`
```
 Marin Alvarez
 Adonis Julius Archer
 Beau Tristan Bentley
 Hunter Uriah Mathew Clarke
 Leo Gardner
 Vaughn Lewis
 London Lindsey
 Mikayla Lopez
 Janet Parsons
 Frankie Conner Ritter
 Shelby Nathan Yoder
```

---

## Continuous Integration (CI)

GitHub Actions automatically builds and tests the solution for every push to the `main` branch.

CI file: `.github/workflows/dotnet.yml`

```yaml
- dotnet restore
- dotnet build --configuration Release
- dotnet test --configuration Release
```

---

## Solution provided by:

**Sandisiwe Vutula**   
sandisiwevutula28@gmail.com  
Cape Town, South Africa  
[GitHub Profile](https://github.com/Sandisiwe-Vutula)

---