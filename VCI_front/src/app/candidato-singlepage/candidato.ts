export class Candidato{
    constructor(
        public nombre:String,
        public apellidos:String,
        public foto:String,
        public edad:number,
        public cedula:number,
        public partido:String,
        public biografia:Text,
        public propuestas: Propuesta[]
    ){}
}

export class Propuesta{
    constructor(
        public titulo:String,
        public descripcion:Text
    ){}
}