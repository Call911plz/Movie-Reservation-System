# Movie-Reservation-System
Movie reservation system as descibed in roadmap.sh projects.

Standard Model, View, Controller, Service.
- Model accessing db
- Service accessing model's db data + handling logic
- Controller accessing service as View demands
- View serving user and calling Controller as needed

# Requirements

## User Authentication and Authorization
---
- [X] Users should be able to sign up and log in.
- [X] You also need roles for users, such as admin and regular user. Admins should be able to manage movies and showtimes.
- [ ] Regular users should be able to reserve seats for a showtime.

> You can create the initial admin using seed data. Only admins should be able to promote other users to admin and be able to do things related to movie management, reporting, etc.

## Movie Management
---
- [X] Admins should be able to add, update, and delete movies.
- [ ] Each movie should have a title, description, and poster image.
- [X] Movies should be categorized by genre.
- [ ] Movies should have showtimes.

## Reservation Management
---
- [ ] Users should be able to get the movies and their show times for a specific date.
- [ ] Users should be able to reserve seats for a showtime, see the available seats, and select the seats they want.
- [ ] Users should be able to see their reservations and cancel them (only upcoming ones).
- [ ] Admins should be able to see all reservations, capacity, and revenue.
