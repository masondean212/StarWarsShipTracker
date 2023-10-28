import React from "react";
import { Route, Routes } from "react-router-dom";
import {AppRoutes, AdminRoutes} from "./AppRoutes";
import { Layout } from "./components/Layout";
import useAuth from "./hooks/useAuth";
import Login from "./pages/Login"
import "./custom.css";

function App() {
  const token = useAuth((x) => x.token);
  const currentUser = useAuth((x) => x.currentUser);
  const isLoggedIn = currentUser && token;
  const isAdmin = currentUser?.roles?.some((x) => x.name === "Admin");

  if (!isLoggedIn)
    return (
      <Routes>
        <Route path="*" element={<Login />} />
      </Routes>
    );
 
  return (
    <Layout>
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
        {(isAdmin) ? AdminRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        }) : (null)}
      </Routes>
    </Layout>
  );
}

export default App;
