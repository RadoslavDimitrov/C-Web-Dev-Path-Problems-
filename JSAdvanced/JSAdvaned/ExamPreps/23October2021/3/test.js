const {expect} = require('chai');
const {library} = require('./library.js');

describe("Tests …", function() { 

    describe("calcPriceOfBook", function() { 
        it("shoud work properly", function() {  
            expect(library.calcPriceOfBook('Jumanji', 1981)).to.be.equal(`Price of Jumanji is 20.00`);
        }); 

        it("shoud work properly with empty book name", function() {  
            expect(library.calcPriceOfBook('', 1981)).to.be.equal(`Price of  is 20.00`);
            expect(library.calcPriceOfBook('', 1980)).to.be.equal(`Price of  is 10.00`);
            expect(library.calcPriceOfBook('', 1979)).to.be.equal(`Price of  is 10.00`);
        }); 

        it("shoud work properly with discount", function() {  
            expect(library.calcPriceOfBook('Jumanji', 1980)).to.be.equal(`Price of Jumanji is 10.00`);
        }); 

        it("shoud work properly with discount with year 1979", function() {  
            expect(library.calcPriceOfBook('Jumanji', 1979)).to.be.equal(`Price of Jumanji is 10.00`);
        }); 

        it("shoud throw error with invalid book name", function(){
            expect(() => library.calcPriceOfBook(1, 1981)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(NaN, 1981)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(true, 1981)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(false, 1981)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(undefined, 1981)).to.throw('Invalid input');
        });

        it("shoud throw error with invalid year", function(){
            expect(() => library.calcPriceOfBook('Jumanji', '1981')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', '1980')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', '1979')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', '')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', NaN)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', undefined)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Jumanji', 1.2)).to.throw('Invalid input');
            
        });

        it("shoud throw error with invalid year and book", function(){
            expect(() => library.calcPriceOfBook(1, '1981')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(NaN, '')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(true, NaN)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(undefined, undefined)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(false, 1.2)).to.throw('Invalid input');
            
        });

     }); 
     // TODO: … 

     //example ["Troy", "Life Style", "Torronto", etc.]
     describe("findBook", function(){
        it('shoud work properly -> book founded', function(){
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Troy')).to.be.equal("We found the book you want.");
        });

        it('shoud work properly -> book founded', function(){
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Life Style')).to.be.equal("We found the book you want.");
        });

        // it('shoud work properly -> book founded with empty array properties', function(){
        //     expect(library.findBook(["", "", ""], "")).to.be.equal("We found the book you want.");
        // });

        it('shoud work properly -> book not founded', function(){
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Life')).to.be.equal("The book you are looking for is not here!");
        });

        it('shoud work properly -> book not founded with empty arr properties', function(){
            expect(library.findBook(["", "", ""], 'Life')).to.be.equal("The book you are looking for is not here!");
        });

        it('shoud work properly -> book not founded with case sensetive', function(){
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'life Style')).to.be.equal("The book you are looking for is not here!");
        });

        it('shoud throw error with arr.length = 0', function(){
            expect(() => library.findBook([], 'Troy')).to.throw("No books currently available");
        });

     });

     describe('arrangeTheBooks', function(){
        it('shoud throw error with parameter not integer', function(){
            expect(() => library.arrangeTheBooks('1')).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(NaN)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(undefined)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks('')).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(1.2)).to.throw('Invalid input');
        });

        it('shoud throw error with parameter negative integer', function(){
            expect(() => library.arrangeTheBooks(-1)).to.throw('Invalid input');
        });

        it('shoud work with parameter greater than 40', function(){
            expect(library.arrangeTheBooks(41)).to.be.equal("Insufficient space, more shelves need to be purchased.");
        });

        it('shoud work with parameter 40', function(){
            expect(library.arrangeTheBooks(40)).to.be.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(39)).to.be.equal("Great job, the books are arranged.");
        });

        it('shoud work with parameter 0', function(){
            expect(library.arrangeTheBooks(0)).to.be.equal("Great job, the books are arranged.");
        });
     });

}); 