# Hair Salon

#### A simple web app created as an exercise in using C# and SQL.

#### By Ben Logue, Current as of 7/15/2016

## Description

This web app mimics a business application database you might find at a hair salon. The user is able to add stylists and clients. All clients are assigned to a specific stylist. The user has the ability to edit and delete clients and stylists as well.

|Behavior    |Input   |Output   |
|---|---|---|
|User adds a stylist  | name: "Michaelangelo Smith", action: submit  | New stylist "Michaelangelo Smith" created, and stylist shown in list.  |
|User edits a stylist | old name: "Michaelangelo Smith", new name: "Harry S. Truman"  | Stylist name updated to "Harry S. Truman", new stylist information shown in list.  |
|User deletes stylist | name: "Harry S. Truman", action: delete | "Deleted!", stylist removed from shown list.  |
|User adds a client to a stylist  | name: "Homer J. Simpson", action: submit  | New client "Homer J. Simpson" created, and client shown in list under stylist.  |
|User edits a client | old name: "Homer J. Simpson", new name: "Marge Simpson"  | Client name updated to "Marge Simpson", and new client information shown under stylist.  |
|User deletes client | name: "Marge Simpson", action: delete | "Deleted!", client removed from stylist's client list.  |


## Technologies Used

* C#
* Nancy and Razor View Engines
* XUnit
* MSSQL


## Instructions

* Clone the repository to your computer.
* In PowerShell, navigate to the project directory.
* In PowerShell, enter '>dnu restore' and then '>dnx kestrel'.
* In PowerShell type sqlcmd -S "(localdb)\mssqllocaldb" -i C:\[YOURFILEPATH]\hair_salon\script.sql
* In PowerShell type 'dnx kestrel' to initialize local server.
* Navigate your web browser to http://localhost:5004

## Known Bugs

None

## Contacts

benjamin.logue73@gmail.com

### License

Licensed under the MIT License.

&copy; Ben Logue 2016
