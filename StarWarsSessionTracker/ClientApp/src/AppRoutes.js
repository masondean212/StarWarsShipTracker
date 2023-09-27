import ShipInventory from "./pages/ShipInventory";
import ShipList from "./pages/ShipList";
import Home from "./pages/Home";
import AdminShip from "./pages/AdminShips"
import AddShip from "./pages/AddShip"
import AddShipFeature from "./pages/AddShipFeature"
import CheckDatabase from "./pages/CheckDatabase"

const AppRoutes = [
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
    element: <ShipList />
  },
  {
    path: '/admin',
    element: <AdminShip />
  },
  {
    path: '/admin/add-ship',
    element: <AddShip />
  },
  {
    path: '/admin/add-ship-feature',
    element: <AddShipFeature />
  },
  {
    path: '/admin/update-database',
    element: <CheckDatabase />
  }
];

export default AppRoutes;
