# Async-Inn

## Ola M AL-Shlool / 13-4-2022

This project uses ASP.Net Core framework to implement a simple web app following the MVC pattern.

## ERD Diagram

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
