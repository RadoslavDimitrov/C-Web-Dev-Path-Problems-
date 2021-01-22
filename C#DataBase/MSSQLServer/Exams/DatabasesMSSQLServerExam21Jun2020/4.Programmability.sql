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


