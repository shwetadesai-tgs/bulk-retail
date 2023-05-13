import Mock from "../mock";

const userDB = {
  users: [
    {
      id: "5a7b73f76bed15c94d1e46d4",
      index: 0,
      guid: "c01da2d1-07f8-4acc-a1e3-72dda7310af8",
      isActive: false,
      balance: 2838.08,
      age: 30,
      name: "Stefanie Marsh",
      gender: "female",
      company: "ACIUM",
      email: "stefaniemarsh@acium.com",
      phone: "+1 (857) 535-2066",
      address: "163 Poplar Avenue, Cliffside, Virginia, 4592",
      bd: "2015-02-08T04:28:44 -06:00",
      imgUrl: "/assets/images/face-1.png",
    },
    {
      id: "5a7b73f7f79f4250b96a355a",
      index: 1,
      guid: "3f04aa40-62da-466d-ac14-2b8a5da3d1ce",
      isActive: true,
      balance: 3043.81,
      age: 39,
      name: "Elena Bennett",
      gender: "female",
      company: "FIBRODYNE",
      email: "elenabennett@fibrodyne.com",
      phone: "+1 (994) 570-2070",
      address: "526 Grace Court, Cherokee, Oregon, 7017",
      bd: "2017-11-15T09:04:57 -06:00",
      imgUrl: "/assets/images/face-2.png",
    },
    {
      id: "5a7b73f78b64a02a67204d6e",
      index: 2,
      guid: "e7d9d61e-b657-4fcf-b069-2eb9bfdc44fa",
      isActive: true,
      balance: 1796.92,
      age: 23,
      name: "Joni Cabrera",
      gender: "female",
      company: "POWERNET",
      email: "jonicabrera@powernet.com",
      phone: "+1 (848) 410-2368",
      address: "554 Barlow Drive, Alamo, Michigan, 3686",
      bd: "2017-10-15T12:55:51 -06:00",
      imgUrl: "/assets/images/face-3.png",
    },
    {
      id: "5a7b73f7572e59b231149b94",
      index: 3,
      guid: "47673d82-ab31-48a1-8a16-2c6701573c67",
      isActive: false,
      balance: 2850.27,
      age: 37,
      name: "Gallagher Shaw",
      gender: "male",
      company: "ZILLAR",
      email: "gallaghershaw@zillar.com",
      phone: "+1 (896) 422-3786",
      address: "111 Argyle Road, Graball, Idaho, 7272",
      bd: "2017-11-19T03:38:30 -06:00",
      imgUrl: "/assets/images/face-4.png",
    },
    {
      id: "5a7b73f70f9d074552e13090",
      index: 4,
      guid: "bc9c7cd3-04e0-4095-a933-af28efaf3b3e",
      isActive: false,
      balance: 3743.48,
      age: 26,
      name: "Blanchard Knapp",
      gender: "male",
      company: "ACRODANCE",
      email: "blanchardknapp@acrodance.com",
      phone: "+1 (867) 542-2772",
      address: "707 Malta Street, Yukon, Wyoming, 6861",
      bd: "2014-05-28T01:33:58 -06:00",
      imgUrl: "/assets/images/face-2.png",
    },
    {
      id: "5a7b73f78988bd6e92650473",
      index: 5,
      guid: "08cb947c-e49c-4736-9687-0fca0992ec38",
      isActive: false,
      balance: 3453.79,
      age: 34,
      name: "Parker Rivas",
      gender: "male",
      company: "SLAMBDA",
      email: "parkerrivas@slambda.com",
      phone: "+1 (997) 413-2418",
      address: "543 Roosevelt Place, Tibbie, Minnesota, 6944",
      bd: "2015-01-05T09:55:23 -06:00",
      imgUrl: "/assets/images/face-3.png",
    },
  ],
};

Mock.onGet("/api/user/all").reply((config) => {
  return [200, userDB.users];
});

Mock.onGet("/api/user").reply((config) => {
  const id = config.data;
  const response = userDB.users.find((user) => user.id === id);
  return [200, response];
});

Mock.onPost("/api/user/delete").reply((config) => {
  let user = JSON.parse(config.data);
  let index = { i: 0 };
  userDB.users.forEach((element) => {
    if (element.id === user.id) {
      return [200, userDB.users.splice(index.i, 1)];
    }
    index.i++;
  });
  return [200, userDB.users];
});

Mock.onPost("/api/user/update").reply((config) => {
  let user = JSON.parse(config.data);
  let index = { i: 0 };
  userDB.users.forEach((element) => {
    if (element.id === user.id) {
      userDB.users[index.i] = user;
      return [200, userDB.users];
    }
    index.i++;
  });
  return [200, userDB.users];
});

Mock.onPost("/api/user/add").reply((config) => {
  let user = JSON.parse(config.data);
  userDB.users.push(user);
  return [200, userDB.users];
});
