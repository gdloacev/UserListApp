using System;
using System.Collections.Generic;

namespace UserListApp.Domain
{
    [Serializable]
    internal class User
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Id Id { get; set; }
        public Picture Picture { get; set; }
        public string Nat { get; set; }

        public User(string gender, Name name, Location location, string email, Login login, Dob dob, Registered registered, string phone, string cell, Id id, Picture picture, string nat)
        {
            Gender = gender;
            Name = name;
            Location = location;
            Email = email;
            Login = login;
            Dob = dob;
            Registered = registered;
            Phone = phone;
            Cell = cell;
            Id = id;
            Picture = picture;
            Nat = nat;
        }
    }

    #region "SubClasses"
    internal class Coordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Coordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    internal class Dob
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }

        public Dob(DateTime date, int age)
        {
            Date = date;
            Age = age;
        }
    }

    internal class Id
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Id(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    internal class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public object Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
        public Timezone Timezone { get; set; }

        public Location(Street street, string city, string state, string country, object postcode, Coordinates coordinates, Timezone timezone)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            Postcode = postcode;
            Coordinates = coordinates;
            Timezone = timezone;
        }
    }

    internal class Login
    {
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }

        public Login(string uuid, string username, string password, string salt, string md5, string sha1, string sha256)
        {
            Uuid = uuid;
            Username = username;
            Password = password;
            Salt = salt;
            Md5 = md5;
            Sha1 = sha1;
            Sha256 = sha256;
        }
    }

    internal class Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public Name(string title, string first, string last)
        {
            Title = title;
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            return $"{Title} {First} {Last}";
        }
    }

    public class Picture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }

        public Picture(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }
    }

    internal class Registered
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }

        public Registered(DateTime date, int age)
        {
            Date = date;
            Age = age;
        }
    }

    internal class Street
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Street(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }

    internal class Timezone
    {
        public string Offset { get; set; }
        public string Description { get; set; }

        public Timezone(string offset, string description)
        {
            Offset = offset;
            Description = description;
        }
    }

    internal class Root
    {
        public List<User> Results { get; set; }
        public Info Info { get; set; }

        public Root(){}

        public Root(List<User> results, Info info)
        {
            Results = results;
            Info = info;
        }
    }

    internal class Info
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }

        public Info(string seed, int results, int page, string version)
        {
            Seed = seed;
            Results = results;
            Page = page;
            Version = version;
        }
    }

    #endregion
}
