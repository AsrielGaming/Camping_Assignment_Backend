using add_db.Data;
using LiteDB;
using System;
using System.Collections.Generic;

public class AnonymousCampingDatabase : IAnonymousCampingDataContext
{
    private LiteDatabase _db;

    public AnonymousCampingDatabase()
    {
        _db = new LiteDatabase(@"data.db");
    }

    // User Methods --------------------------------------------------------------------------------------------------------------------------
    public void AddUser(User user)
    {
        _db.GetCollection<User>("Users").Insert(user);
    }

    public IEnumerable<User> GetUsers()
    {
        return _db.GetCollection<User>("Users").FindAll();
    }

    public User GetUserById(int id)
    {
        return _db.GetCollection<User>("Users").FindById(id);
    }

    public void UpdateUsername(int userId, string newUsername)
    {
        var user = _db.GetCollection<User>("Users").FindById(userId);
        if (user != null)
        {
            user.Username = newUsername;
            _db.GetCollection<User>("Users").Update(user);
        }
    }

    public void UpdatePassword(int userId, string newPassword)
    {
        var user = _db.GetCollection<User>("Users").FindById(userId);
        if (user != null)
        {
            user.Password = newPassword;
            _db.GetCollection<User>("Users").Update(user);
        }
    }

    public void UpdateEmail(int userId, string newEmail)
    {
        var user = _db.GetCollection<User>("Users").FindById(userId);
        if (user != null)
        {
            user.Email = newEmail;
            _db.GetCollection<User>("Users").Update(user);
        }
    }

    public void DeleteUser(int userId)
    {
        _db.GetCollection<User>("Users").Delete(userId);
    }

    // owner methods --------------------------------------------------------------------------------------------------------------------------
    public void AddOwner(Owner owner)
    {
        _db.GetCollection<Owner>("Owners").Insert(owner);
    }

    public IEnumerable<Owner> GetOwners()
    {
        return _db.GetCollection<Owner>("Owners").FindAll();
    }

    public Owner GetOwnerById(int id)
    {
        return _db.GetCollection<Owner>("Owners").FindById(id);
    }

    public void DeleteOwner(int id)
    {
        _db.GetCollection<Owner>("Owners").Delete(id);
    }
    public void UpdateOwnerName(int ownerId, string newName)
    {
        var owner = _db.GetCollection<Owner>("Owners").FindById(ownerId);
        if (owner != null)
        {
            owner.OwnerName = newName;
            _db.GetCollection<Owner>("Owners").Update(owner);
        }
    }

    public void UpdateOwnerEmail(int ownerId, string newEmail)
    {
        var owner = _db.GetCollection<Owner>("Owners").FindById(ownerId);
        if (owner != null)
        {
            owner.Email = newEmail;
            _db.GetCollection<Owner>("Owners").Update(owner);
        }
    }

    public void UpdateOwnerPassword(int ownerId, string newPassword)
    {
        var owner = _db.GetCollection<Owner>("Owners").FindById(ownerId);
        if (owner != null)
        {
            owner.Password = newPassword;
            _db.GetCollection<Owner>("Owners").Update(owner);
        }
    }

    public void UpdateOwnerPhoneNumber(int ownerId, string newPhoneNumber)
    {
        var owner = _db.GetCollection<Owner>("Owners").FindById(ownerId);
        if (owner != null)
        {
            owner.PhoneNumber = newPhoneNumber;
            _db.GetCollection<Owner>("Owners").Update(owner);
        }
    }

    // CampingGround methods --------------------------------------------------------------------------------------------------------------------------
    public void AddCampingGround(CampingGround campingGround)
    {
        _db.GetCollection<CampingGround>("CampingGrounds").Insert(campingGround);
    }

    public void UpdateCampingGround(int campingGroundId, CampingGround updatedCampingGround)
    {
        var existingCampingGround = _db.GetCollection<CampingGround>("CampingGrounds").FindById(campingGroundId);
        if (existingCampingGround != null)
        {
            existingCampingGround.Name = updatedCampingGround.Name;
            existingCampingGround.AmountOfCampingSpots = updatedCampingGround.AmountOfCampingSpots;
            existingCampingGround.Location = updatedCampingGround.Location;
            existingCampingGround.IsPetFriendly = updatedCampingGround.IsPetFriendly;
            _db.GetCollection<CampingGround>("CampingGrounds").Update(existingCampingGround);
        }

    }

    public void UpdateCampingSpotCampType(int campingSpotId, int campTypeId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        if (campingSpot != null)
        {
            campingSpot.CampTypeId = campTypeId;
            _db.GetCollection<CampingSpot>("CampingSpots").Update(campingSpot);
        }
    }

    public void UpdateCampingSpotAmenities(int campingSpotId, List<int> amenityIds)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        if (campingSpot != null)
        {
            campingSpot.AmenityIds = amenityIds;
            _db.GetCollection<CampingSpot>("CampingSpots").Update(campingSpot);
        }
    }

    public void DeleteCampingGround(int campingGroundId)
    {
        _db.GetCollection<CampingGround>("CampingGrounds").Delete(campingGroundId);
    }

    public IEnumerable<CampingGround> GetCampingGrounds()
    {
        return _db.GetCollection<CampingGround>("CampingGrounds").FindAll();
    }

    public string GetName(int campingGroundId)
    {
        var campingGround = _db.GetCollection<CampingGround>("CampingGrounds").FindById(campingGroundId);
        return campingGround?.Name ?? "";
    }

    public int GetAmountOfCampingSpots(int campingGroundId)
    {
        var campingGround = _db.GetCollection<CampingGround>("CampingGrounds").FindById(campingGroundId);
        return campingGround?.AmountOfCampingSpots ?? 0;
    }

    public string GetLocation(int campingGroundId)
    {
        var campingGround = _db.GetCollection<CampingGround>("CampingGrounds").FindById(campingGroundId);
        return campingGround?.Location ?? "";
    }

    public bool GetIsPetFriendly(int campingGroundId)
    {
        var campingGround = _db.GetCollection<CampingGround>("CampingGrounds").FindById(campingGroundId);
        return campingGround?.IsPetFriendly ?? false;
    }

    // CampingSpot methods --------------------------------------------------------------------------------------------------------------------------
    public void AddCampingSpot(CampingSpot campingSpot)
    {
        _db.GetCollection<CampingSpot>("CampingSpots").Insert(campingSpot);
    }

    public IEnumerable<CampingSpot> GetCampingSpots()
    {
        return _db.GetCollection<CampingSpot>("CampingSpots").FindAll();
    }

    public void UpdateCampingSpot(int campingSpotId, CampingSpot updatedCampingSpot)
    {
        var existingCampingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        if (existingCampingSpot != null)
        {
            existingCampingSpot.SpotName = updatedCampingSpot.SpotName;
            existingCampingSpot.Size = updatedCampingSpot.Size;
            existingCampingSpot.Description = updatedCampingSpot.Description;
            existingCampingSpot.Price = updatedCampingSpot.Price;
            existingCampingSpot.IsAvailable = updatedCampingSpot.IsAvailable;
            _db.GetCollection<CampingSpot>("CampingSpots").Update(existingCampingSpot);
        }
    }

    public void DeleteCampingSpot(int campingSpotId)
    {
        _db.GetCollection<CampingSpot>("CampingSpots").Delete(campingSpotId);
    }

    public IEnumerable<CampingSpot> GetCampingSpotsByOwner(int ownerId)
    {
        return _db.GetCollection<CampingSpot>("CampingSpots").Find(c => c.OwnerId == ownerId);
    }

    public IEnumerable<CampingSpot> GetCampingSpotsByCampingGround(int campingGroundId)
    {
        return _db.GetCollection<CampingSpot>("CampingSpots").Find(c => c.CampingGroundId == campingGroundId);
    }

    public string GetSpotName(int campingSpotId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        return campingSpot?.SpotName ?? ""; //?? "" deals with empty string 
    }

    public int GetSize(int campingSpotId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        return campingSpot?.Size ?? 0;
    }

    public string GetDescription(int campingSpotId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        return campingSpot?.Description ?? "";
    }

    public decimal GetPrice(int campingSpotId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        return campingSpot?.Price ?? 0;
    }

    public bool GetIsAvailable(int campingSpotId)
    {
        var campingSpot = _db.GetCollection<CampingSpot>("CampingSpots").FindById(campingSpotId);
        return campingSpot?.IsAvailable ?? false;
    }

    // Booking methods --------------------------------------------------------------------------------------------------------------------------
    public void AddBooking(Booking booking)
    {
        _db.GetCollection<Booking>("Bookings").Insert(booking);
    }

    public IEnumerable<Booking> GetBookings()
    {
        return _db.GetCollection<Booking>("Bookings").FindAll();
    }

    public IEnumerable<Booking> GetBookingsByUserId(int userId)
    {
        return _db.GetCollection<Booking>("Bookings").Find(x => x.UserId == userId);
    }

    public IEnumerable<Booking> GetBookingsBySpotId(int spotId)
    {
        return _db.GetCollection<Booking>("Bookings").Find(x => x.SpotId == spotId);
    }

    public Booking GetBookingById(int id)
    {
        return _db.GetCollection<Booking>("Bookings").FindById(id);
    }

    public void UpdateBooking(int id, Booking updatedBooking)
    {
        var existingBooking = _db.GetCollection<Booking>("Bookings").FindById(id);
        if (existingBooking != null)
        {
            // Ensure the ID is retained
            updatedBooking.Id = existingBooking.Id; // Set the ID to match the existing document's ID

            // Retain the existing string values for CheckInDate and CheckOutDate
            updatedBooking.CheckInDate = existingBooking.CheckInDate;
            updatedBooking.CheckOutDate = existingBooking.CheckOutDate;

            _db.GetCollection<Booking>("Bookings").Update(updatedBooking);
        }
    }

    public void DeleteBooking(int id)
    {
        _db.GetCollection<Booking>("Bookings").Delete(id);
    }
    
    // CampType methods --------------------------------------------------------------------------------------------------------------------------
    public void AddCampType(Camptype campType)
    {
        _db.GetCollection<Camptype>("CampTypes").Insert(campType);
    }

    public void UpdateCampType(int campTypeId, Camptype updatedCampType)
    {
        var existingCampType = _db.GetCollection<Camptype>("CampTypes").FindById(campTypeId);
        if (existingCampType != null)
        {
            existingCampType.TypeName = updatedCampType.TypeName;
            _db.GetCollection<Camptype>("CampTypes").Update(existingCampType);
        }
    }

    public void DeleteCampType(int campTypeId)
    {
        _db.GetCollection<Camptype>("CampTypes").Delete(campTypeId);
    }

    public IEnumerable<Camptype> GetCampTypes()
    {
        return _db.GetCollection<Camptype>("CampTypes").FindAll();
    }

    // Amenity methods --------------------------------------------------------------------------------------------------------------------------
    public void AddAmenity(Amenity amenity)
    {
        _db.GetCollection<Amenity>("Amenities").Insert(amenity);
    }

    public void UpdateAmenity(int amenityId, Amenity updatedAmenity)
    {
        var existingAmenity = _db.GetCollection<Amenity>("Amenities").FindById(amenityId);
        if (existingAmenity != null)
        {
            existingAmenity.Name = updatedAmenity.Name;
            _db.GetCollection<Amenity>("Amenities").Update(existingAmenity);
        }
    }

    public void DeleteAmenity(int amenityId)
    {
        _db.GetCollection<Amenity>("Amenities").Delete(amenityId);
    }

    public IEnumerable<Amenity> GetAmenities()
    {
        return _db.GetCollection<Amenity>("Amenities").FindAll();
    }

    // Rating methods --------------------------------------------------------------------------------------------------------------------------
    public void AddRating(Rating rating)
    {
        _db.GetCollection<Rating>("Ratings").Insert(rating);
    }

    public IEnumerable<Rating> GetRatings()
    {
        return _db.GetCollection<Rating>("Ratings").FindAll();
    }

    public IEnumerable<Rating> GetRatingsByCampingSpot(int campingSpotId)
    {
        return _db.GetCollection<Rating>("Ratings").Find(r => r.CampingSpotId == campingSpotId);
    }

    public IEnumerable<Rating> GetRatingsByUser(int userId)
    {
        return _db.GetCollection<Rating>("Ratings").Find(r => r.UserId == userId);
    }

    public void DeleteRating(int ratingId)
    {
        _db.GetCollection<Rating>("Ratings").Delete(ratingId);
    }

    public void UpdateRating(int ratingId, Rating updatedRating)
    {
        var existingRating = _db.GetCollection<Rating>("Ratings").FindById(ratingId);
        if (existingRating != null)
        {
            existingRating.CampingSpotId = updatedRating.CampingSpotId;
            existingRating.UserId = updatedRating.UserId;
            existingRating.Score = updatedRating.Score;
            _db.GetCollection<Rating>("Ratings").Update(existingRating);
        }
    }

    public int GetRatingScore(int ratingId)
    {
        var rating = _db.GetCollection<Rating>("Ratings").FindById(ratingId);
        return rating?.Score ?? 0;
    }

    // Comment methods --------------------------------------------------------------------------------------------------------------------------
    public void AddComment(Comment comment)
    {
        _db.GetCollection<Comment>("Comments").Insert(comment);
    }

    public IEnumerable<Comment> GetComments()
    {
        return _db.GetCollection<Comment>("Comments").FindAll();
    }

    public IEnumerable<Comment> GetCommentsByCampingSpot(int campingSpotId)
    {
        return _db.GetCollection<Comment>("Comments").Find(c => c.CampingSpotId == campingSpotId);
    }

    public IEnumerable<Comment> GetCommentsByUser(int userId)
    {
        return _db.GetCollection<Comment>("Comments").Find(c => c.UserId == userId);
    }

    public void DeleteComment(int commentId)
    {
        _db.GetCollection<Comment>("Comments").Delete(commentId);
    }

    public void UpdateComment(int commentId, Comment updatedComment)
    {
        var existingComment = _db.GetCollection<Comment>("Comments").FindById(commentId);
        if (existingComment != null)
        {
            existingComment.CampingSpotId = updatedComment.CampingSpotId;
            existingComment.UserId = updatedComment.UserId;
            existingComment.Text = updatedComment.Text;
            _db.GetCollection<Comment>("Comments").Update(existingComment);
        }
    }

    public string GetCommentText(int commentId)
    {
        var comment = _db.GetCollection<Comment>("Comments").FindById(commentId);
        return comment?.Text ?? "";
    }

    // amenity methods (intermediate table) --------------------------------------------------------------------------------------------------------------------------
    public void AddAmenityToCampingSpot(int campingSpotId, int amenityId)
    {
        var campingSpotAmenity = new CampingSpotAmenity { CampingSpotId = campingSpotId, AmenityId = amenityId };
        _db.GetCollection<CampingSpotAmenity>("CampingSpotAmenities").Insert(campingSpotAmenity);
    }

    public void RemoveAmenityFromCampingSpot(int campingSpotId, int amenityId)
    {
        var collection = _db.GetCollection<CampingSpotAmenity>("CampingSpotAmenities");
        var query = Query.And(Query.EQ("CampingSpotId", campingSpotId), Query.EQ("AmenityId", amenityId));
        collection.DeleteMany(query);
    }

    public IEnumerable<Amenity> GetAmenitiesForCampingSpot(int campingSpotId)
    {
        var amenityIds = _db.GetCollection<CampingSpotAmenity>("CampingSpotAmenities")
            .Find(x => x.CampingSpotId == campingSpotId)
            .Select(x => x.AmenityId)
            .ToList();

        return _db.GetCollection<Amenity>("Amenities").Find(x => amenityIds.Contains(x.Id));
    }

    // camping spot type methods (intermediate table) --------------------------------------------------------------------------------------------------------------------------
    public void AddCampTypeToCampingSpot(int campingSpotId, int campTypeId)
    {
        var campingSpotCampsiteType = new CampingSpotType { CampingSpotId = campingSpotId, CampTypeId = campTypeId };
        _db.GetCollection<CampingSpotType>("CampingSpotCampsiteTypes").Insert(campingSpotCampsiteType);
    }

    public void RemoveCampTypeFromCampingSpot(int campingSpotId, int campTypeId)
    {
        var collection = _db.GetCollection<CampingSpotType>("CampingSpotCampsiteTypes");
        var query = Query.And(Query.EQ("CampingSpotId", campingSpotId), Query.EQ("CampTypeId", campTypeId));
        collection.DeleteMany(query);
    }

    public IEnumerable<Camptype> GetCampTypesForCampingSpot(int campingSpotId)
    {
        var campsiteTypeIds = _db.GetCollection<CampingSpotType>("CampingSpotCampsiteTypes")
            .Find(x => x.CampingSpotId == campingSpotId)
            .Select(x => x.CampTypeId)
            .ToList();

        return _db.GetCollection<Camptype>("CampTypes").Find(x => campsiteTypeIds.Contains(x.Id));
    }


}
