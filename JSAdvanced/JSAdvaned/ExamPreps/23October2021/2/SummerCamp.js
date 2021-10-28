class SummerCamp{
    constructor(organizer, location){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            "child": 150, 
            "student": 300, 
            "collegian": 500
        }
        this.listOfParticipants = []
    }

    //posible conditions = ("child", "student", "collegian")
    registerParticipant (name, condition, money) {
        if(!this.priceForTheCamp.hasOwnProperty(condition)){
            throw Error('Unsuccessful registration at the camp.');
        }

        if(this.listOfParticipants.some(p => p.name == name)){
            return `The ${name} is already registered at the camp.`;
        }

        if(money < this.priceForTheCamp[condition]){
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        })

        return `The ${name} was successfully registered.`;
    }


    unregisterParticipant (name){
        if(!this.listOfParticipants.some(p => p.name == name)){
            throw Error(`The ${name} is not registered in the camp.`);
        }

        let index = this.listOfParticipants.findIndex(p => p.name == name);
        this.listOfParticipants.splice(index, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay (typeOfGame, participant1, participant2) {

        if(typeOfGame == 'WaterBalloonFights'){
            if(!this.listOfParticipants.some(p => p.name == participant1) || 
            !this.listOfParticipants.some(p => p.name == participant2)){
                throw Error(`Invalid entered name/s.`);
            }

            let player1 = this.listOfParticipants.find(pl => pl.name == participant1);
            let player2 = this.listOfParticipants.find(pl => pl.name == participant2);

            if(player1.condition != player2.condition){
                throw Error(`Choose players with equal condition.`);
            }

            if(player1.power > player2.power){
                player1.wins++;
                return `The ${player1.name} is winner in the game ${typeOfGame}.`;
            }
            else if(player1.power < player2.power){
                player2.wins++;
                return `The ${player2.name} is winner in the game ${typeOfGame}.`;
            }
            else{
                return `There is no winner.`;
            }

        }
        else{
            if(!this.listOfParticipants.some(p => p.name == participant1)){
                throw Error(`Invalid entered name/s.`);
            }

            let player = this.listOfParticipants.find(pl => pl.name == participant1);
            player.power += 20;

            return `The ${player.name} successfully completed the game ${typeOfGame}.`;
        }
    }


    toString (){
        let result = [];
        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);

        let orderedParticipants = this.listOfParticipants.sort((a, b) => {
            return b.wins - a.wins;
        })

        for (const player of orderedParticipants) {
            result.push(`${player.name} - ${player.condition} - ${player.power} - ${player.wins}`);
        }

        return result.join('\n');
    }
}

const summerCamp = new SummerCamp('Jane Austen', 'Pancharevo Sofia 1137, Bulgaria'); 

console.log(summerCamp.registerParticipant('Petar Petarson', 'child', 300)); 

console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200)); 

console.log(summerCamp.timeToPlay('Battleship', 'Sara Dickinson')); 

console.log(summerCamp.timeToPlay('WaterBalloonFights', 'Sara Dickinson','Petar Petarson')); 

console.log(summerCamp.toString()); 