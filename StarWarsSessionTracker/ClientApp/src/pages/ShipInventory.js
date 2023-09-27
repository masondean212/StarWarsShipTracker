import React, { useState } from 'react';

function ShipInventory() {
  const [currentCount, setCurrentCount] = useState(0);

  function incrementCount() {
    setCurrentCount(currentCount + 1);
  }

  return (
    <div>
      <h1>Ship Inventory</h1>

      <p>This is a simple example of a React component.</p>

      <p aria-live="polite">Current count: <strong>{currentCount}</strong></p>

      <button className="btn btn-primary" onClick={incrementCount}>Increment</button>
    </div>
  );

}
export default ShipInventory;
