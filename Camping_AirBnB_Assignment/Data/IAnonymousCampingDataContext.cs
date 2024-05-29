using System.Collections.Generic;

namespace add_db.Data
{
    public interface IAnonymousCampingDataContext
    {

        // User methods --------------------------------------------------------------------------------------------------------------------------
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void UpdateUsername(int userId, string newUsername);
        void UpdatePassword(int userId, string newPassword);
        void UpdateEmail(int userId, string newEmail);
        void DeleteUser(int userId);

        // owner methods --------------------------------------------------------------------------------------------------------------------------
        void AddOwner(Owner owner);
        IEnumerable<Owner> GetOwners();
        Owner GetOwnerById(int id);
        void DeleteOwner(int id);
        void UpdateOwnerName(int ownerId, string newName);
        void UpdateOwnerEmail(int ownerId, string newEmail);
        void UpdateOwnerPassword(int ownerId, string newPassword);
        void UpdateOwnerPhoneNumber(int ownerId, string newPhoneNumber);

        // CampingGround methods --------------------------------------------------------------------------------------------------------------------------
        void AddCampingGround(CampingGround campingGround);
        void UpdateCampingGround(int campingGroundId, CampingGround updatedCampingGround);
        void DeleteCampingGround(int campingGroundId);
        IEnumerable<CampingGround> GetCampingGrounds();
        string GetName(int campingGroundId);
        int GetAmountOfCampingSpots(int campingGroundId);
        string GetLocation(int campingGroundId);
        bool GetIsPetFriendly(int campingGroundId);

        // CampingSpot methods --------------------------------------------------------------------------------------------------------------------------
        void AddCampingSpot(CampingSpot campingSpot);
        IEnumerable<CampingSpot> GetCampingSpots();
        void UpdateCampingSpot(int campingSpotId, CampingSpot updatedCampingSpot);
        void DeleteCampingSpot(int campingSpotId);
        IEnumerable<CampingSpot> GetCampingSpotsByOwner(int ownerId);
        IEnumerable<CampingSpot> GetCampingSpotsByCampingGround(int campingGroundId);
        string GetSpotName(int campingSpotId);
        int GetSize(int campingSpotId);
        string GetDescription(int campingSpotId);
        decimal GetPrice(int campingSpotId);
        bool GetIsAvailable(int campingSpotId);
        void UpdateCampingSpotCampType(int campingSpotId, int campTypeId);
        void UpdateCampingSpotAmenities(int campingSpotId, List<int> amenityIds);

        // Booking methods --------------------------------------------------------------------------------------------------------------------------
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
        IEnumerable<Booking> GetBookingsByUserId(int userId);
        IEnumerable<Booking> GetBookingsBySpotId(int spotId);
        Booking GetBookingById(int id);
        void UpdateBooking(int id, Booking updatedBooking);
        void DeleteBooking(int id);

        // CampType methods --------------------------------------------------------------------------------------------------------------------------
        void AddCampType(Camptype campType);
        void UpdateCampType(int campTypeId, Camptype updatedCampType);
        void DeleteCampType(int campTypeId);
        IEnumerable<Camptype> GetCampTypes();

        // Amenity methods --------------------------------------------------------------------------------------------------------------------------
        void AddAmenity(Amenity amenity);
        void UpdateAmenity(int amenityId, Amenity updatedAmenity);
        void DeleteAmenity(int amenityId);
        IEnumerable<Amenity> GetAmenities();

        // Rating methods --------------------------------------------------------------------------------------------------------------------------
        void AddRating(Rating rating);
        IEnumerable<Rating> GetRatings();
        IEnumerable<Rating> GetRatingsByCampingSpot(int campingSpotId);
        IEnumerable<Rating> GetRatingsByUser(int userId);
        void DeleteRating(int ratingId);
        void UpdateRating(int ratingId, Rating updatedRating);
        int GetRatingScore(int ratingId);

        // Comment methods --------------------------------------------------------------------------------------------------------------------------
        void AddComment(Comment comment);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentsByCampingSpot(int campingSpotId);
        IEnumerable<Comment> GetCommentsByUser(int userId);
        void DeleteComment(int commentId);
        void UpdateComment(int commentId, Comment updatedComment);
        string GetCommentText(int commentId);

        // Amenity methods (intermediate table) --------------------------------------------------------------------------------------------------------------------------
        void AddAmenityToCampingSpot(int campingSpotId, int amenityId);
        void RemoveAmenityFromCampingSpot(int campingSpotId, int amenityId);
        IEnumerable<Amenity> GetAmenitiesForCampingSpot(int campingSpotId);

        // CampTypes methods (intermediate table) --------------------------------------------------------------------------------------------------------------------------
        void AddCampTypeToCampingSpot(int campingSpotId, int campTypeId);
        void RemoveCampTypeFromCampingSpot(int campingSpotId, int campTypeId);
        IEnumerable<Camptype> GetCampTypesForCampingSpot(int campingSpotId);

    }
}
