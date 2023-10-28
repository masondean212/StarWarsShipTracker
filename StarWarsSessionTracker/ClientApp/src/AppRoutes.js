import ShipInventory from "./pages/ShipInventory";
import ShipList from "./pages/ShipList";
import Home from "./pages/Home";
import AdminShip from "./pages/AdminShips"
import ModifyShip from "./pages/ModifyShip"
import AddShipFeature from "./pages/AddShipFeature"
import UserList from "./pages/UserList"
import UserForm from "./pages/UserForm"

export const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/ship-inventory',
    element: <ShipInventory />
  },
  {
    path: '/ship-list',
    element: <ShipList adminRoute={false}/>
  }
];

export const AdminRoutes = [
  {
    path: '/admin',
    element: <AdminShip />
  },
  {
    path: '/admin/edit-ship/:shipId',
    element: <ModifyShip />
  },
  {
    path: '/admin/add-ship-feature',
    element: <AddShipFeature />
  },
  {
    path: '/admin/user-list',
    element: <UserList />
  },
  {
    path: '/admin/create-user',
    element: <UserForm />
  },
  {
    path: '/admin/ship-list',
    element: <ShipList adminRoute={true}/>
  }
];
