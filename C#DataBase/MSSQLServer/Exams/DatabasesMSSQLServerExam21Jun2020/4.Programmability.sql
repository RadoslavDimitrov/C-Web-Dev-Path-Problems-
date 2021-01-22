CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	--room total price = (HotelBaseRate + RoomPrice) * PeopleCount

		DECLARE @roomId INT = (SELECT TOP(1) r.Id
								FROM Trips as t
								JOIN Rooms as r ON t.RoomId = r.Id
								JOIN Hotels as h ON h.Id = r.HotelId
								WHERE
									h.Id = @HotelId
									AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
									AND t.CancelDate IS NULL
									AND r.Beds >= @People
									AND YEAR(@Date) = YEAR(t.ArrivalDate)
									ORDER BY r.Price DESC);
		
		IF @roomId IS NULL
			RETURN 'No rooms available';

		DECLARE @roomType NVARCHAR(MAX) = (SELECT r.Type
												FROM Rooms as r
												WHERE r.Id = @roomId)

		DECLARE @beds INT = (SELECT r.Beds
								FROM Rooms as r
								WHERE r.Id = @roomId)

		DECLARE @roomPrice DECIMAL(18,2) = (SELECT r.Price
											FROM Rooms as r
											WHERE r.Id = @roomId)

		DECLARE @hotelBaseRate DECIMAL(18,2) = (SELECT h.BaseRate
													FROM Hotels as h
													WHERE h.Id = @HotelId)

		DECLARE @totalPrice DECIMAL(18,2) = (@hotelBaseRate + @roomPrice) * @People

		RETURN CONCAT('Room ', @roomId, ': ', @roomType,' (', @beds, ' beds) - $', @totalPrice);

		--Room 211: First Class (5 beds) - $202.80
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2);

--Room 211: First Class (5 beds) - $202.80 

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3);
--No rooms available



--Switch Room 


CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	--target room -> hotel id
	IF(
		(SELECT TOP(1) h.Id
				FROM Rooms as r
				JOIN Hotels as h ON r.HotelId = h.Id
				WHERE r.Id = @TargetRoomId) != (SELECT h.Id
												FROM Trips as t
												JOIN Rooms as r ON t.RoomId = r.Id
												JOIN Hotels as h ON r.HotelId = h.Id
												WHERE t.Id = @TripId))
		THROW 50001, 'Target room is in another hotel!', 1
		--beds
	IF((SELECT Beds
		FROM Rooms
		WHERE Id = @TargetRoomId) < (SELECT COUNT(*) as [Count]
										FROM AccountsTrips
										WHERE TripId = @TripId))
		THROW 50002, 'Not enough beds in target room!', 1;

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId

END			

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10 

EXEC usp_SwitchRoom 10, 7 
--Target room is in another hotel!

EXEC usp_SwitchRoom 10, 8 
--Not enough beds in target room!