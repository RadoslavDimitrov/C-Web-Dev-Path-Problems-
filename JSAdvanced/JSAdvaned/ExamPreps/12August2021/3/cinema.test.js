let {expect} = require('chai');
let {cinema} = require('./cinema.js');

describe("Cinema", function() { 

    describe("showMovies", function() { 
        it("shoud work with one movie …", function() { 
            expect(cinema.showMovies(['King Kong'])).to.be.equal('King Kong');
        }); 

        it("shoud work with one movie …", function() { 
            expect(cinema.showMovies([0])).to.be.equal('0');
        }); 

        it("shoud work with more than one movie …", function() { 
            expect(cinema.showMovies(['King Kong', 'The Tomorrow War', 'Joker']))
            .to.be.equal('King Kong, The Tomorrow War, Joker');
        }); 

        it("shoud return message with empty arr", function(){
            expect(cinema.showMovies([])).to.be.equal("There are currently no movies to show.");
        });
     }); 


     describe("ticketPrice", function(){
         it("shoud throw error message with invalid input", function(){
            expect(() => cinema.ticketPrice("invalid")).to.throw('Invalid projection type.');
         });

         it("shoud return price", function(){
            expect(cinema.ticketPrice("Premiere")).to.be.equal(12.00);
            expect(cinema.ticketPrice("Normal")).to.be.equal(7.50);
            expect(cinema.ticketPrice("Discount")).to.be.equal(5.50);
         });
     })

     describe("swapSeatsInHall", function(){
        it("shoud return message with one missing seat", function(){
            expect(cinema.swapSeatsInHall(5)).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud return message with one null seat", function(){
            expect(cinema.swapSeatsInHall(null,5)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(5,null)).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud return message with one non number seat", function(){
            expect(cinema.swapSeatsInHall(5, '5')).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall('5', 5)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall('5', '5')).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud return message with one greater number seat", function(){
            expect(cinema.swapSeatsInHall(1, 21)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(21, 1)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(21, 22)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(0, 20)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(20, 0)).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud return message with one zero number seat", function(){
            expect(cinema.swapSeatsInHall(1, 0)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(0, 1)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(0, 0)).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud return message with one negative number seat", function(){
            expect(cinema.swapSeatsInHall(-1, 1)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(1, -1)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(-1, -1)).to.be.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(1, 1)).to.be.equal("Unsuccessful change of seats in the hall.");
        })

        it("shoud work properly", function(){
            expect(cinema.swapSeatsInHall(5, 10)).to.be.equal("Successful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(20, 1)).to.be.equal("Successful change of seats in the hall.");
        })
     })

}); 