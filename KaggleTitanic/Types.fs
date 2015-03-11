namespace KaggleTitanic

type Sex = Male | Female
type Port = Cherbourg | Queenstown | Southampton

type Record =
    { PassengerId: int
      Survived: bool
      Class: int
      Name: string
      Sex: Sex
      Age: float
      SiblingsSpouses: int
      ParentsChildren: int
      TicketNumber: string
      Fare: float
      Cabin: string
      Port: Port option }
