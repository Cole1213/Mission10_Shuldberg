import { useEffect, useState } from 'react';
import { Bowlers } from '../Types/Bowlers';

function DataList() {
  const [bowlerData, setBowlerData] = useState<Bowlers[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const rsp = await fetch('http://localhost:5264/Bowler');
      const f = await rsp.json();
      setBowlerData(f);
    };

    fetchData();
  }, []);

  return (
    <div className="card-container">
      {bowlerData.map((x: any) => (
        <div className="card">
          <div className="card-content">
            <h2 className="card-title">
              Name: {x.bowlerFirstName} {x.bowlerMiddleInit} {x.bowlerLastName}
            </h2>
            <h3 className="card-description">Team: {x.teamName}</h3>
            <p>
              Address: {x.bowlerAddress} <br /> {x.bowlerCity}, {x.bowlerState}{' '}
              {x.bowlerZip}
            </p>
            <p>Phone: {x.bowlerPhoneNumber}</p>
          </div>
        </div>
      ))}
    </div>
  );
}

export default DataList;
