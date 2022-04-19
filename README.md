# Async-Inn

## Ola M AL-Shlool / 13-4-2022 / 18-4-2022 / 20-4-2022

This project uses ASP.Net Core framework to implement a simple web app following the MVC pattern.

## How do you run the program?

1. Clone repo to your device.
2. Open the solution file Async-Inn.sln in Visual Studio.
3. To run the app, go to Debug > Start Without Debugging (or press ctrl+F5).
## ERD Diagram
![ERD Diagram](assets/async-inn-erd.png)
## Explanation of ERD Diagram
- ### Hotel
    Locations is a class which holds the properties Name, City, State, Address, and PhoneNumber. All of these are VarChar except ID, which is an int.

Connected to HotelRoom.

- ### HotelRoom
    Has composite Foreign Key or HotelID and RoomID, and create a composite key called RoomNumber. It has the properties of Rate(decimal) and PetFriendly(bit).

    Connected to Hotel/Room.

- ### Room
    Has an ID, Name(string) and Layout(int). Layout receives data from a connected enum list.

    Is connected to Layout/RoomAmenities.

- ### Layout
    List of three room type: Studio, OneBedroom, and TwoBedroom. Connects to Room and nothing else.

- ### RoomAmenities
    Feeds into Room. and receives its ID. Also receives Amenities ID.

- ### Amenity
    Simple class with just an ID and a Name property.


![ERD Diagram](assets/Diagram.png)

## Explanation of ERD Diagram

- ### Location Table

  Consists of one primary key, and it has the properties of name, city, state, address, and phone number. Relationship (one-to-many) to the join table Rooms, through its primary key.

- ### Rooms

  Join table linking the Location (one-to-many) and Room (many-to-one) tables through their primary keys. Rooms have a composite key consisting of LocationID and RoomNumber.

- ### Room

  Consists of a primary key, and the basic attributes of a room. Relation to the Amenities table (one-to-many) and the EnumRoomLayout enum (many-to-one).

- ### EnumRoomLayout (Enum)

  The enum Layout contains the properties of studio, one bedroom, and two bedrooms

- ### Amenities

  Possible amenities for a given room. Has a primary key.
