node posts/posts.js 8082
node ./users/users.js 8081

http://localhost:8082/posts

localhost:8082/assignment
POST {"userId": 8, "postId": 6}

//Управление инвентарём склада

item 
{
    id:1111,
    name: wood;
    size: {size: big, middle, small},
}
const sizes = [
  { id: 0, name: 'big' },
  { id: 1, name: 'middle' },
  { id: 2, name: 'small' },
];


person
{
    id: 111, 
    name: 'Bob',
    occupations: [0, 1],
}
const occupations = [
  { id: 0, name: 'manager' },
  { id: 1, name: 'seller' },
  { id: 2, name: 'packer' },
];

storehouse
{
    id: 4,
    displayName: 'Storagehouse 4',
    necessaryOccupations : ['seller'],
    necessarySizes: ['middle'],
    assignedPerson: 0
}

склад-человек
на склад могут пройти определённые люди (ограничение на складе) (manager, packer, seller)
последнее посещение склада человеком (запрос со склада, как в примере)

склад-вещь
на склад могут положить вещь с особыми спецификами (big, middle, small iteam)
